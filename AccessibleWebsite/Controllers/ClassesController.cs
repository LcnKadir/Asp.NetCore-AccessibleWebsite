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

        public async Task<IActionResult> Index(int id) //Trainer'ları ve dersleri listeliyoruz.
        {
            var clas = await _classService.GetClassIdAsync(id);

            var trainer = await _appUserService.GetAllAsync();
            var classes = await _classService.GetAllAsync();

            ViewBag.GetTrainer = new SelectList(trainer, "TrainerId", "Name");
            ViewBag.classes = new SelectList(classes, "Id", "Name");

            return View(clas);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterClass(Message msg, int clasId)
        {
            msg.CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            await _messageService.AddAsync(msg);
            return RedirectToAction("Index", "Classes", new { id = clasId });
        }

    }
}
