using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.Helpers
{
    public class PasswordEncryption
    {

        //Encriptar la contraseña con Sha256
        public static string ComputedSha256Hash(string password)
        {
            //Crear SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));


                //Convert Byte Array to a String

                StringBuilder builder = new();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }


        }

    }
}
