//using Emarket.Core.Domain.Common;
//using Emarket.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Red_Social.Core.Domain.Commom;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Emarket.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }



        DbSet<User> User { get; set; }
        DbSet<Friend> Friend { get; set; }
        DbSet<Comment> Comment { get; set; }
        DbSet<Post> Post { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        //Fluent Api

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region  ===> Naming Tables
            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<Friend>()
                .ToTable("Friends");

            modelBuilder.Entity<Comment>()
                .ToTable("Comments");

            modelBuilder.Entity<Post>()
                .ToTable("Posts");
            #endregion


            #region ===> Primary Keys
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);

            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);

            modelBuilder.Entity<Comment>()
                .HasKey(comment => comment.Id);

            modelBuilder.Entity<Post>()
                .HasKey(post => post.Id);

            #endregion


            #region ==> Relationships or Foreign Keys
            //modelBuilder.Entity<User>()
            //    .HasKey(t => new {t.Frie})
            //    .HasMany<Friend>(user => user.Friends)
            //    .WithMany(friend => friend.Friends)
            //    .HasForeignKey(advertisement => advertisement.)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<User>().HasMany(
            //            user => user.Friends).WithMany(friend => friend.Users).
            //            UsingEntity<Dictionary<string, object>>(
            //                "M2MTable",
            //                b => b.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
            //                b => b.HasOne<Book>().WithMany().HasForeignKey("BookId"));

            modelBuilder.Entity<User>()
                .HasMany<Comment>(user => user.Comments)
                .WithOne(comment => comment.User)
                .HasForeignKey(comment => comment.UserId)
                .OnDelete(DeleteBehavior.NoAction); //I changed From Cascade to No action

            modelBuilder.Entity<User>()
                .HasMany<Post>(user => user.Posts)
                .WithOne(post => post.User)
                .HasForeignKey(post => post.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //Aqui la Many to many de User
           // modelBuilder.Entity<UserFriend>()
           //.HasKey(e => new { e.UserId, e.FriendId });  //OJO


            modelBuilder.Entity<User>()
                .HasMany(user => user.Friends)
                .WithMany(friend => friend.Users)
                .UsingEntity<Friend>(
                    j => j
                        .HasOne(friend => friend.User)
                        .WithMany(user => user.UserFriends)
                        .HasForeignKey(friend => friend.UserId),
                    j => j
                        .HasOne(friend => friend.Friendd)
                        .WithMany(user => user.FriendsUser)
                        .HasForeignKey(friend => friend.FriendId),
                    j =>
                        {
                            j.ToTable("Friends");
                            j.HasKey(e => new { e.UserId, e.FriendId });
                        });



            modelBuilder.Entity<Post>()
                .HasMany<Comment>(post => post.Comments)
                .WithOne(comment => comment.Post)
                .HasForeignKey(comment => comment.PostId)
                .OnDelete(DeleteBehavior.Cascade);








    //        modelBuilder.Entity<Comment>()
    //.HasMany<Post>(comment => comment.Post)
    //.WithOne(post => post.Post)
    //.HasForeignKey(comment => comment.PostId)
    //.OnDelete(DeleteBehavior.Cascade);



            //Esto puede causar error
            //modelBuilder.Entity<Post>()
            //    .HasOne<Post>(post => post.Posts)
            //    .WithOne(post => post.Posts)
            //    .HasForeignKey<Post>(post => post.IdPostShared)
            //    .OnDelete(DeleteBehavior.Cascade);



            #endregion


            #region "Property Configuration"

            #region User
            modelBuilder.Entity<User>().Property(user => user.Name).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Email).IsRequired();
            //modelBuilder.Entity<User>().Property(user => user.ProfilePhotoUrl).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Username).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Password).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Name).IsRequired();
            #endregion


            #region Post
            modelBuilder.Entity<Post>().Property(post => post.Text).IsRequired();
            #endregion


            #region Comment
            modelBuilder.Entity<Comment>().Property(comment => comment.Text).IsRequired();
            #endregion

            #endregion


        }
    }
}
