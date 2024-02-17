using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace AccessibleWebsite.Controllers
{
    [AllowAnonymous]
    public class BlogsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IBlogService _blogService;

        public BlogsController(ICommentService commentService, UserManager<AppUser> userManager, IBlogService blogService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _blogService = blogService;
        }

        //Blogların Ana Sayfası.
        public async Task<IActionResult> Index()
        {
            return View(await _blogService.GetBlogWithTrainer());
        }


        [HttpGet]
        public async Task<ActionResult> BlogDetails()
        {
            var blog = await _blogService.GetBlogAsync();
            return View(blog);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            comment.CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            await _commentService.AddAsync(comment);
            return RedirectToAction(nameof(Index));
        }


    }
}
