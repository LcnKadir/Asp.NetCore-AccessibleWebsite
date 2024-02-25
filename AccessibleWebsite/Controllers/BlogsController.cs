using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace AccessibleWebsite.Controllers
{
    public class BlogsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public BlogsController(ICommentService commentService, IBlogService blogService, ICategoryService categoryService)
        {
            _commentService = commentService;
            _blogService = blogService;
            _categoryService = categoryService;
        }


        //Blogların Ana Sayfası.
        public async Task<IActionResult> Index()
        {
            var value = await _blogService.GetBlogWithTrainer();

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;

            return View(value);

        }


        [HttpGet]
        public async Task<ActionResult> BlogDetails(int id)
        {
            var blog = await _blogService.GetDetailsBlogAsync(id);
            return View(blog);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment, int blogId)
        {
            comment.CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            await _commentService.AddAsync(comment);
            return RedirectToAction("BlogDetails", "Blogs", new { id = blogId });
        }


    }
}
