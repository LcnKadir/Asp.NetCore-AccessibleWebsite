using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Üye")]
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;

        public ClassController(IClassService classService, UserManager<AppUser> userManager, IMessageService messageService)
        {
            _classService = classService;
            _userManager = userManager;
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> ListSelectedClass()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var clases = await _messageService.GetwasPickClass(user.Id);
            return View(clases);
        }


        [HttpGet]
        public async Task<IActionResult> ListAllClass()
        {
            return View(await _classService.GetAllAsync());
        }
    }
}
