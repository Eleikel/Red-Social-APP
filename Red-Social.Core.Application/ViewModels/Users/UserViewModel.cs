using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Users
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public string Phone { get; set; }

        public string VerificationCode { get; set; }


        //public ICollection<Post> Posts { get; set; }
        //public ICollection<Comment> Comments { get; set; }

        public ICollection<UserViewModel> Users { get; set; }
        public ICollection<UserViewModel> Friends { get; set; }


        //public ICollection<Friend> UserFriends { get; set; }
        //public ICollection<Friend> FriendsUser { get; set; }

    }
}
