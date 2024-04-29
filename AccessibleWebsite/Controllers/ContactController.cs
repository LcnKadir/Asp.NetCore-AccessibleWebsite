using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStoryService _storyService;

        public ContactController(UserManager<AppUser> userManager, IStoryService storyService)
        {
            _userManager = userManager;
            _storyService = storyService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(Story story)
        {
            await _storyService.AddStoryAsync(story);
            return RedirectToAction(nameof(Index));
        }
    }
}
