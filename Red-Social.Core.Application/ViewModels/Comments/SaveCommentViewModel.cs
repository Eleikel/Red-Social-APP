using Red_Social.Core.Application.ViewModels.Post;
using Red_Social.Core.Application.ViewModels.Users;
using Red_Social.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Comments
{
    public class SaveCommentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debes ingresar el contenido del Post")]
        [DataType(DataType.Text)]
        public string Text { get; set; }


        public int UserId { get; set; }
        //public UserViewModel User { get; set; }

        public int PostId { get; set; }
        //public PostViewModel Post { get; set; }

        //public ICollection<Comment> Comments;


    }
}
