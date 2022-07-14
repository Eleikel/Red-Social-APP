using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Users
{
    public class RestorePasswordViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Inserte el nombre de usuario")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

    }
}
