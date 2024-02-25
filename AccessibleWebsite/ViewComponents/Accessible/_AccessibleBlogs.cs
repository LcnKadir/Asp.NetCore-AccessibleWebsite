using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Accessible
{
    public class _AccessibleBlogs: ViewComponent
    {
        private readonly IBlogService _blogService;

        public _AccessibleBlogs(IBlogService blogService)
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
