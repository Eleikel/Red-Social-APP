using Microsoft.AspNetCore.Http;
using Red_Social.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Infrastructure.Shared.Services
{
    public class UploadFileService : IUploadFileService
    {

        //private readonly IUploadFileService _uploadFileService;




        //Upload File
        public string UploadFile(IFormFile file, int id, bool isEditMode = false, string imageUrl = "")
        {
            if (isEditMode)
            {
                if (file == null)
                {
                    return imageUrl;
                }
            }

            //get directory path
            string basePath = $"/Images/Users/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //Create folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //get file path
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string filenameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(filenameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }


            //Borrar la Imagen Antigua cuando editamos
            if (isEditMode)
            {
                string[] oldImagePart = imageUrl.Split("/");
                string oldImageName = oldImagePart[^1];   // '^1' = Ultima posicion
                string completeImageOldPath = Path.Combine(path, oldImageName);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }

            return $"{basePath}/{fileName}";
        }
    }
}
