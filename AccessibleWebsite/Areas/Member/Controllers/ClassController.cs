using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Member.Controllers
{
    [Area("Member")]
    public class ClassController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IClassService _classService;

        public ClassController(UserManager<AppUser> userManager, IClassService classService)
        {
            _userManager = userManager;
            _classService = classService;
        }

        public async Task<IActionResult> ListClass()
        {
            return View(await _classService.GetAllAsync());
        }
    }
}
