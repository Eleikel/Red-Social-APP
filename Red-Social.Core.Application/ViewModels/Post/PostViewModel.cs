using Red_Social.Core.Application.ViewModels.Comments;
using Red_Social.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }



        public int UserId { get; set; }
        public UserViewModel User { get; set; }

        public ICollection<CommentViewModel> Comments;


        public int? IdPostShared { get; set; }
        public PostViewModel Posts { get; set; }

        //
        public string UserName {get; set; }
        public string UserPhoto { get; set; }

        public DateTime Created { get; set; }

    }
}
