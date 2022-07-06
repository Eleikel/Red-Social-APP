using Red_Social.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public string VerificationCode { get; set; }


        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<User> Friends { get; set; }
        public ICollection<Friend> UserFriends { get; set; }
        public ICollection<Friend> FriendsUser { get; set; }




    }
}
