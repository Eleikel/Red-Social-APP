using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.ViewModels.Comments;
using Red_Social.Core.Application.ViewModels.Post;
using Red_Social.Middleware;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Red_Social.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly ValidateUserSession _validateUserSession;
        private readonly IUploadFileService _uploadFileService;

        public PostController(IPostService postService, ValidateUserSession validateUserSession, IUploadFileService uploadFileService)
        {
            _postService = postService;
            _validateUserSession = validateUserSession;
            _uploadFileService = uploadFileService;
        }



        
        public async Task<IActionResult> Index(SavePostViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            ViewBag.Posts = await _postService.GetAllViewModel();

            return View(vm);

        }


        public IActionResult Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            return View("Index", new SavePostViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePostViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                //ModelState.AddModelError("", $"Debes Ingresar");
                return RedirectToAction("Index", vm);
            }

            SavePostViewModel productVm = await _postService.Add(vm);

            if (productVm.Id != 0 && productVm != null)
            {
                productVm.ImageUrl = UploadFile(vm.File, productVm.Id);

                await _postService.Update(productVm, productVm.Id);
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            SavePostViewModel vm = await _postService.GetByIdSaveViewModel(id);
            return View("Edit", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePostViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", vm);
            }

            SavePostViewModel postVm = await _postService.GetByIdSaveViewModel(vm.Id);
            vm.ImageUrl = UploadFile(vm.File, vm.Id, true, postVm.ImageUrl);
            await _postService.Update(vm, vm.Id);
            return RedirectToRoute(new { controller = "Post", action = "Index" });
        }




        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            return View(await _postService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            await _postService.Delete(id);

            string basePath = $"/Images/Products/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(path))
            {
                DirectoryInfo directory = new(path);

                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo folder in directory.GetDirectories())
                {
                    folder.Delete(true);
                }

                Directory.Delete(path);
            }

            return RedirectToRoute(new { controller = "Post", action = "Index" });
        }



        //public  IActionResult Comment()
        //{
        //    //return RedirectToRoute(new { controller = "User", action = "Index" });
        //    return View("Index");

        //}

        //[HttpPost]
        //public async Task<IActionResult> Comment(SaveCommentViewModel vm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        //return View("SaveCategory", vm);
        //        return RedirectToAction("Index", vm);

        //    }

        //    await _commentService.Add(vm);
        //    return RedirectToRoute(new { controller = "Post", action = "Index" });
        //}






        ////Comments
        //public IActionResult Comment()
        //{
        //    if (!_validateUserSession.HasUser())
        //    {
        //        return RedirectToRoute(new { controller = "User", action = "Index" });
        //    }

        //    return View("Index", new PostViewModel());
        //}




        //[HttpPost]
        //public async Task<IActionResult> Comment(SavePostViewModel vm)
        //{
        //    if (!_validateUserSession.HasUser())
        //    {
        //        return RedirectToRoute(new { controller = "User", action = "Index" });
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index", vm);
        //    }

        //    SavePostViewModel productVm = await _postService.Add(vm);

        //    if (productVm.Id != 0 && productVm != null)
        //    {
        //        productVm.ImageUrl = _uploadFileService.UploadFile(vm.File, productVm.Id);

        //        await _postService.Update(productVm, productVm.Id);
        //    }

        //    return RedirectToAction("Index");
        //}




        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string imagePath = "")
        {
            if (isEditMode)
            {
                if (file == null)
                {
                    return imagePath;
                }
            }
            string basePath = $"/Images/Products/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //create folder if not exist
            if (!Directory.Exists(path))
            {

                Directory.CreateDirectory(path);
            }

            //get file extension
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imagePath.Split("/");
                string oldImagePath = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImagePath);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }
            return $"{basePath}/{fileName}";
        }

    }





}
