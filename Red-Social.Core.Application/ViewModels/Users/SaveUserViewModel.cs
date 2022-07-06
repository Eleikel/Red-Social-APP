using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Users
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Inserte el nombre de usuario")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Inserte una contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Las contraseñas deben coincidir")]
        [Required(ErrorMessage = "Inserte una contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Inserte un nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Inserte un apellido")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }


        //[Required(ErrorMessage = "Inserte su foto de Perfil")]
        [DataType(DataType.Text)]
        public string ProfilePhotoUrl { get; set; }

        [Required(ErrorMessage = "Inserte un Correo")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Inserte un telefono")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }


        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }

        [DataType(DataType.Text)]
        public string VerificationCode { get; set; }
        public DateTime Created { get; set; }

    }
}
