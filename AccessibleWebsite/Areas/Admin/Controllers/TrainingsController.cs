using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TrainingsController : Controller
    {
        private readonly ITrainingService _trainingService;
        private readonly IAppUserService _appUserService;

        public TrainingsController(ITrainingService trainingService, IAppUserService appUserService)
        {
            _trainingService = trainingService;
            _appUserService = appUserService;
        }

        [HttpGet]
        public async Task<IActionResult> ListTrainings()
        {
            ViewBag.Trainers = await _appUserService.GetTrainers();
            return View(await _trainingService.GetAllTrainingAsync());
        }
    }
}
