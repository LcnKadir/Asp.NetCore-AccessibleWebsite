using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace AccessibleWebsite.Areas.Member.Controllers
{
    [Area("Member")]
    public class TrainingController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ITrainingService _trainingService;
        private readonly IAppUserService _appUserService;

        public TrainingController(UserManager<AppUser> userManager, ITrainingService trainingService, IAppUserService appUserService)
        {
            _userManager = userManager;
            _trainingService = trainingService;
            _appUserService = appUserService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            var training = await _trainingService.GetwasPickTraining(user.Id);

            ViewBag.Trainers = await _appUserService.GetAllAsync();

            return View(training);
        }
    }
}
