using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StoryController : Controller
    {
        private readonly IStoryService _storyService;

        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _storyService.GetAllStoryAsync();
            return View(users);
        }

        public async Task<IActionResult> GetPublish(int id)
        {
            var users = await _storyService.GetByIdAsync(id);
            users.Published = true;
            await _storyService.UpdateAsync(users);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PullPublish(int id)
        {
            var users = await _storyService.GetByIdAsync(id);
            users.Published = false;
            await _storyService.UpdateAsync(users);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteStory(int id)
        {
            var story = await _storyService.GetByIdAsync(id);
            await _storyService.RemoveAsync(story);
            return RedirectToAction(nameof(Index));
        }
    }
}
