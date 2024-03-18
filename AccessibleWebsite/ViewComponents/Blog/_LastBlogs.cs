using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Blog
{
    public class _LastBlogs : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public _LastBlogs(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;

        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _blogService.GetLastBlogAsync(id);
            await _categoryService.GetAllAsync();
            return View(values);

        }
    }
}
