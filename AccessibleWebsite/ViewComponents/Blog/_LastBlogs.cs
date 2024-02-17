using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Blog
{
    public class _LastBlogs : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _LastBlogs(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _blogService.GetLastBlogAsync(id);
            return View(values);

        }
    }
}
