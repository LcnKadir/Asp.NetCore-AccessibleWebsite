using AccessibleWebsite.Models;
using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Services;

namespace AccessibleWebsite.Controllers
{
    [AllowAnonymous]
    public class ClassesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IClassService _classService;
        private readonly IAppUserService _appUserService;
        private readonly IMessageService _messageService;

        public ClassesController(UserManager<AppUser> userManager, IClassService classService, IAppUserService appUserService, IMessageService messageService)
        {
            _userManager = userManager;
            _classService = classService;
            _appUserService = appUserService;
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var classes = await _classService.GetAllAsync();
            var days = await _classService.GetAllAsync();
            ViewBag.Classes = classes;
            ViewBag.Days = days;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterClass(Message msg, List<int> clasId)
        {
            await _messageService.AddAsync(msg);
            return RedirectToAction("Index", "Classes", new { id = clasId });
        }

    }
}
