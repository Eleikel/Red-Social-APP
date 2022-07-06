using Red_Social.Core.Application.ViewModels.Post;
using Red_Social.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Comments
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
    
        public int UserId { get; set; }
        public UserViewModel User { get; set; }

        public int PostId { get; set; }
        public PostViewModel Post { get; set; }

    }
}