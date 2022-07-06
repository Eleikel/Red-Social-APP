using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.ViewModels.Users
{
    public class VerifyViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Inserte el Codigo de Confirmación de Correo para Activar esta cuenta")]

        public string VerificationCode { get; set; }

        //public string Password { get; set; }

    }
}
