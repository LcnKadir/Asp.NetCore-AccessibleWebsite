using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Accessible
{
    public class _AccessTestimonial : ViewComponent
    {
        private readonly IStoryService _storyService;

        public _AccessTestimonial(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var stories = await _storyService.SelectedStories(id);
            return View(stories);
        }
    }
}
