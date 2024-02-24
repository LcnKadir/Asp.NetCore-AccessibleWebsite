using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Default
{
    public class _DefaultBlogs : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _DefaultBlogs(IBlogService blogService)
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
