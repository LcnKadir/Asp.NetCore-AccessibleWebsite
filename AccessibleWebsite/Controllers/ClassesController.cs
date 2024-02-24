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
    public class ClassesController : Controller
    {
        private readonly IClassService _classService;
        private readonly IMessageService _messageService;

        public ClassesController(IClassService classService, IMessageService messageService)
        {
            _classService = classService;
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var getclass = await _classService.GetClassWithTrainer(); //Derslerin sayfada listelenmesi.

            var classes = await _classService.GetAllAsync();
            var days = await _classService.GetAllAsync();
            ViewBag.Classes = classes;
            ViewBag.Days = days;

            return View(getclass);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RegisterClass(Message msg, List<int> clasId) //Ders kaydı.
        {
            await _messageService.AddAsync(msg);
            return RedirectToAction("Index", "Classes", new { id = clasId });
        }

        
    }
}
