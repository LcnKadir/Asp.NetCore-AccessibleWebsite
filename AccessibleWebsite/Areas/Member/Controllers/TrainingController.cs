using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Member.Controllers
{
    [Area("Member")]
    public class TrainingController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ITrainingService _trainingService;

        public TrainingController(UserManager<AppUser> userManager, ITrainingService trainingService)
        {
            _userManager = userManager;
            _trainingService = trainingService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
