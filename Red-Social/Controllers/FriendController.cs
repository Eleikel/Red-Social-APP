using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Red_Social.Core.Application.Helpers;
using Red_Social.Core.Application.Interfaces.Repositories;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.ViewModels.Friends;
using Red_Social.Core.Application.ViewModels.Users;
using Red_Social.Core.Domain.Entities;
using Red_Social.Middleware;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Red_Social.Controllers
{
    public class FriendController : Controller
    {
        private readonly IFriendService _friendService;
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;
        private readonly IFriendRepository _friendRepository;

        private readonly ValidateUserSession _validateUserSession;

        public FriendController(IFriendService friendService, ICommentService commentService, IPostService postService, IUserService userService, IFriendRepository friendRepository, ValidateUserSession validateUserSession, IHttpContextAccessor httpContextAccessor)
        {
            _validateUserSession = validateUserSession;
            _friendService = friendService;
            _commentService = commentService;
            _postService = postService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            _friendRepository = friendRepository;
        }

        public async Task<IActionResult> Index(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            //Post List
            //ViewBag.Posts = await _postService.GetAllViewModelWithInclude(userViewModel.Id); //GetAllViewModel
            ViewBag.Posts = await _postService.GetPostList(userViewModel.Id); //GetAllViewModel
            //ViewBag.UserId = Id;

            var SavefriendVm = await _friendService.GetAllViewModel();

            //Lista de mis Amigos
            ViewBag.FriendList = await _friendService.GetAllViewModelWithInclude(userViewModel.Id); //Mi UserId

            return View(new SaveFriendViewModel());
        }

        //AÑADIR AMIGO
        [HttpPost]
        public async Task<IActionResult> Index(SaveFriendViewModel vm, int id)
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", vm);
            }

            //var frienList = _friendService.GetAllViewModelWithInclude(vm.Id);
            //var userList = _userService.GetAllViewModel();

            //var listaUsuarios = new List<User>();
            //foreach (var item in userList)
            //{
            //    listaUsuarios.Add(item);
            //}


            if (!await _userService.Exist(vm.Username))
            {
                ModelState.AddModelError("", $"El Username {vm.Username} no existe.");
                //return View("Index", vm);

                return RedirectToRoute(new { controller = "Friend", action = "Index" });

            }


            else
            {

                var getAllUser = await _userService.GetAllViewModel();

                string newPassword = string.Empty;
                newPassword = Guid.NewGuid().ToString("N").Substring(0, 3);

                //int Id = Int32.Parse(newPassword);

                foreach (var item in getAllUser)
                {
                    if (item.Username == vm.Username)
                    {
                        vm.Id = item.Id;
                        vm.FriendId = item.Id;
                        vm.Username = item.Username;
                        vm.UserId = userViewModel.Id;
                    }
                }

                //SaveUserViewModel userVm = await _userService.GetByIdSaveViewModel(vm.FriendId);

                SaveFriendViewModel SavefriendVm = await _friendService.Add(vm);

                return RedirectToRoute(new { controller = "Friend", action = "Index" });///
            }

        }






        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

                

            return View(await _friendService.GetFriendByIdSaveViewModel(userViewModel.Id, id));

        }


        [HttpPost]
        public async Task<IActionResult> DeletePost(SaveFriendViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            await _friendService.DeleteFriend(vm.UserId, vm.FriendId);
            return RedirectToRoute(new { controller = "Friend", action = "Index" });
        }
    }
}
