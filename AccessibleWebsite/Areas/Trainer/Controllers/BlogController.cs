using AccessibleWebsite.Controllers;
using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;
using System.Reflection.Metadata;

namespace AccessibleWebsite.Areas.Trainer.Controllers
{
    [Area("Trainer")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryService _categoryService;

        public BlogController(IBlogService blogService, UserManager<AppUser> userManager, ICategoryService categoryService)
        {
            _blogService = blogService;
            _userManager = userManager;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> ListBlogs()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user != null)
            {
                var appUser = new AppUser
                {
                    Id = user.Id
                };

                var value = await _blogService.GetBlogForTrainer(appUser.Id);
                ViewBag.Categories = await _categoryService.GetAllAsync();
                return View(value);
            }
            else
            {
                return NotFound();
            }
        }



        [HttpGet]
        public async Task<IActionResult> AddBlog()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Categories = await _categoryService.GetAllAsync();
            ViewBag.userId = user.Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog blog)
        {

            if (blog.ImageUrl != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(blog.ImageUrl.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/BlogImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await blog.ImageUrl.CopyToAsync(stream);
                blog.Image = imagename;
            }
            if (blog.CoverImageUrl != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(blog.CoverImageUrl.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/BlogImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await blog.CoverImageUrl.CopyToAsync(stream);
                blog.CoverImage = imagename;
            }
            if (blog.ImageUrlTwo != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(blog.ImageUrlTwo.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/BlogImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await blog.ImageUrlTwo.CopyToAsync(stream);
                blog.ImageTwo = imagename;
            }

            blog.CreateDate = DateTime.Now;
            await _blogService.AddAsync(blog);
            return RedirectToAction(nameof(ListBlogs));
        }


        [HttpGet]
        public async Task<IActionResult> EditBlog(int id)
        {
            var values = await _blogService.GetByIdAsync(id);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userId = user.Id;

            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> EditBlog(Blog blog)
        {

            if (blog.ImageUrl != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(blog.ImageUrl.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/BlogImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await blog.ImageUrl.CopyToAsync(stream);
                blog.Image = imagename;
            }
            if (blog.CoverImageUrl != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(blog.CoverImageUrl.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/BlogImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await blog.CoverImageUrl.CopyToAsync(stream);
                blog.CoverImage = imagename;
            }
            if (blog.ImageUrlTwo != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(blog.ImageUrlTwo.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/BlogImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await blog.ImageUrlTwo.CopyToAsync(stream);
                blog.ImageTwo = imagename;
            }

            blog.CreateDate = DateTime.Now;
            await _blogService.UpdateAsync(blog);
            return RedirectToAction(nameof(ListBlogs));
        }


        public async Task<IActionResult> DeleteBlog(int id)
        {
            var value = await _blogService.GetByIdAsync(id);
            await _blogService.RemoveAsync(value);
            return RedirectToAction(nameof(ListBlogs));

        }
    }
}
