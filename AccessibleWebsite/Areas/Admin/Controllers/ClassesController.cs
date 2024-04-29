using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ClassesController : Controller
    {
        private readonly IClassService _classService;
        private readonly IAppUserService _appUserService;

        public ClassesController(IClassService classService, IAppUserService appUserService)
        {
            _classService = classService;
            _appUserService = appUserService;
        }

        [HttpGet]
        public async Task<IActionResult> ListClasses()
        {


            var classes = await _classService.GetAllAsync();
            ViewBag.Trainers = await _appUserService.GetTrainers();
            return View(classes);
        }
    }
}
