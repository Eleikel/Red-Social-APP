using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Red_Social.Core.Application.Helpers;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.ViewModels.Comments;
using Red_Social.Core.Application.ViewModels.Post;
using Red_Social.Core.Application.ViewModels.Users;
using Red_Social.Middleware;
using System.Threading.Tasks;

namespace Red_Social.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        public readonly ValidateUserSession _validateUserSession;
        private readonly UserViewModel userViewModel;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public CommentController(ICommentService commentService, IPostService postService, IHttpContextAccessor httpContextAccessor, ValidateUserSession validateUserSession)
        {
            _validateUserSession = validateUserSession;
            _commentService = commentService;
            _postService = postService;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");

        }
        public async Task<IActionResult> Index(int Id)
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            ViewBag.Comments = await _commentService.GetAllViewModelWithInclude(Id);
            ViewBag.PostId = Id;

            return View(new SaveCommentViewModel());
        }



        [HttpPost]
        public async Task<IActionResult> Create(SaveCommentViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", vm);
            }

            SaveCommentViewModel CommentVm = await _commentService.Add(vm);

            return RedirectToRoute(new { controller = "Comment", action = "Index", id= CommentVm.PostId });
        }
    }
}
