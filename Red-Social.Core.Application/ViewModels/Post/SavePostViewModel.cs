using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Post
{
    public class SavePostViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debes ingresar el contenido del Post")]
        [DataType(DataType.Text)]
        public string Text { get; set; }

        public string ImageUrl { get; set; }

        //[Required(ErrorMessage = "Debes ingresar el contenido del Post")]
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }

        public int UserId { get; set; }
        public DateTime Created { get; set; }



    }
}
