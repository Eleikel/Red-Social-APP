using Microsoft.AspNetCore.Mvc;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Application.ViewModels.Comments;
using System.Threading.Tasks;

namespace Red_Social.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<IActionResult> Index()
        {
            //return View();
            return View(await _commentService.GetAllViewModel());

        }

        public IActionResult Create()
        {
            return View("SaveComment", new SaveCommentViewModel()); 


            //SaveCommentViewModel vm = new();
            //vm.Comments = await _commentService.GetAllViewModel();
            //return View("SaveComment");
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveCommentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                //return View("SaveCategory", vm);
                return RedirectToAction("SaveComment", vm);

            }

            await _commentService.Add(vm);
            return RedirectToRoute(new { controller = "Comment", action = "Index" });
        }
    }
}
