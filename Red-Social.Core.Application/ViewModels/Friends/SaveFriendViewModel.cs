using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Friends
{
    public class SaveFriendViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } //

        public int UserId { get; set; }

        public int FriendId { get; set; }

    }
}
