using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Application.Interfaces.Services
{
    public interface IUploadFileService
    {

        string UploadFile(IFormFile file, int id, bool isEditMode = false, string imageUrl = "");

    }
}
