
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Red_Social.Core.Application.Dtos.Email;
using Red_Social.Core.Application.Helpers;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.ViewModels.Users;
using Red_Social.Core.Domain.Entities;
using Red_Social.Middleware;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Red_Social.Controllers
{
    public class UserController : Controller
    {

        public readonly IUserService _userService;
        public readonly ValidateUserSession _validateUserSession;
        public readonly IUploadFileService _uploadFileService;
        private readonly IEmailService _emailService;
        //private ApplicationUserManager _userManager;

        public UserController(IUserService userService, ValidateUserSession validateUserSession, IUploadFileService uploadFileService, IEmailService emailService)
        {
            _userService = userService;
            _uploadFileService = uploadFileService;
            _validateUserSession = validateUserSession;
            _emailService = emailService;

        }
        //Iniciar Session or Log In
        public IActionResult Index()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Post", action = "Index" });
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginVm)
        {

            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Post", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }



            UserViewModel userVm = await _userService.Login(loginVm);

            if (userVm != null )
            {
                if (userVm.VerificationCode != null && userVm.Password == userVm.VerificationCode)
                {
                    HttpContext.Session.Set<UserViewModel>("user", userVm);
                    return RedirectToRoute(new { controller = "Post", action = "Index" });
                }
                else
                {

                    ModelState.AddModelError("userValidation", "Debes Activar tu cuenta desde el Correo");
                }

            }
            else
            {
                ModelState.AddModelError("userValidation", "Acceso a los datos incorrecto");
            }

            return View(loginVm);
        }



        public IActionResult Register()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Post", action = "Index" });
            }

            return View(new SaveUserViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel vm/*, string returnUrl = null*/)
        {
            //if (_validateUserSession.HasUser())
            //{
            //    return RedirectToRoute(new { controller = "Home", action = "Index" });
            //}
            if (!ModelState.IsValid)
            {
                return View("Register", vm);
            }

            if (await _userService.Exist(vm.Username))
            {
                ModelState.AddModelError("", $"El Username {vm.Username} ya existe.");
                return View("Register", vm);
            }


            SaveUserViewModel userVm = await _userService.Add(vm);

            if (userVm.Id != 0 && userVm != null)
            {
                userVm.ProfilePhotoUrl = _uploadFileService.UploadFile(vm.File, userVm.Id);

                await _userService.Update(userVm, userVm.Id); //Segundo parametro vm.Id

            }

            return RedirectToAction("ValidateEmail", new { id = userVm.Id });
        }


        public async Task<IActionResult> ValidateEmail(int id)
        {
            SaveUserViewModel vm = await _userService.GetByIdSaveViewModel(id);
            return View("ValidateEmail");
        }




        [HttpPost]
        public async Task<IActionResult> ValidateEmail(VerifyViewModel vm, int id)
        {
            if (!ModelState.IsValid)
            {
                return View("ValidateEmail");
            }

            SaveUserViewModel userVm = await _userService.GetByIdSaveViewModel(id);

            if (userVm.VerificationCode == null && userVm.Password == vm.VerificationCode)
            {
                userVm.VerificationCode = userVm.Password;

                await _userService.Update(userVm, userVm.Id);
            }
            else
            {
                ModelState.AddModelError("", $"El codigo de Activacion de la cuenta es Incorrecto");
                return View("ValidateEmail");

            }

            return RedirectToRoute(new { controller = "User", action = "Index" });
        }





        public IActionResult RestorePassword(RestorePasswordViewModel vm/*, int id*/)
        {
            return View("RestorePassword");
        }

        [HttpPost]
        public async Task<IActionResult> RestorePassword(RestorePasswordViewModel vm, int id)
        {

            if (!ModelState.IsValid)
            {
                return View("RestorePassword", vm);
            }
            //var query = await
            //SaveUserViewModel userVm = await _userService.GetByIdSaveViewModel(id);
            //var userName = vm.Username;

            if (!await _userService.Exist(vm.Username))
            {
                ModelState.AddModelError("", $"El Username {vm.Username} no existe.");
                return View("RestorePassword", vm);
            }
            else
            {
                var getAllUser = await _userService.GetAllViewModel();

                var name = String.Empty;
                int Id = 0;

                foreach (var item in getAllUser)
                {
                    if (item.Username == vm.Username)
                    {
                        name = item.Username;
                        Id = item.Id;
                    }
                }

                string newPassword = string.Empty;
                newPassword = Guid.NewGuid().ToString("N").Substring(0, 10);

                SaveUserViewModel userVm = await _userService.GetByIdSaveViewModel(Id);


                userVm.Password = newPassword;
                userVm.VerificationCode = userVm.Password;



                await _emailService.SendAsync(new EmailRequest
                {
                    To = userVm.Email,
                    Subject = $"Welcome {userVm.Username} to Red Social App",
                    Body = $"<h1>Hello, </h1> <p>Your username is {userVm.Username}</p>" +
                        $"Your new Password is <b>{newPassword}</b>"
                });

                await _userService.Update(userVm, userVm.Id);


                //RestorePasswordViewModel userVm = await _userService.AutoPassWordGenerate(vm);

                //if (userVm.VerificationCode == null && userVm.Password == vm.VerificationCode)
                //{
                //    userVm.VerificationCode = vm.VerificationCode;

                //    await _userService.Update(userVm, userVm.Id);
                //}

                //await _userService.GetByIdSaveViewModel(vm.Id);

                //ModelState.AddModelError("", $"Is working");
                return View("Index");

            }

            //return RedirectToRoute(new { controller = "User", action = "Index" });
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }


    }
}

