using Red_Social.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Friends
{
    public class FriendViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }

        public int FriendId { get; set; }

        public UserViewModel Friendd { get; set; }

        public string FriendName { get; set; }
        public string FriendLastName { get; set; }

        public string UserName { get; set; }

        public string PhotoProfile { get; set; }

    }
}
