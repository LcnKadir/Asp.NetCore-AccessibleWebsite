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
        public async Task<ActionResult> BlogDetails(int id)
        {
            var blog = await _blogService.GetDetailsBlogAsync(id);
            return View(blog);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment, int blogId )
        {
            comment.CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            await _commentService.AddAsync(comment);
            return RedirectToAction("BlogDetails", "Blogs", new { id = blogId });
        }


    }
}
