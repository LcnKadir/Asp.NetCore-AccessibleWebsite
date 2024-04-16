using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ServiceLayer.Services;

namespace AccessibleWebsite.Areas.Trainer.Controllers
{
    [Area("Trainer")]

    public class TrainingController : Controller
    {
        private readonly ITrainingService _trainingService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appuserService;

        public TrainingController(ITrainingService trainingService, UserManager<AppUser> userManager, IAppUserService appuserService)
        {
            _trainingService = trainingService;
            _userManager = userManager;
            _appuserService = appuserService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View(await _trainingService.GetAllTrainingAsync());
        }


        public async Task<IActionResult> SelectTrainingStatus(int id)
        {
            var oldtrainer = await _trainingService.GetTrainerForTraining(id);

            var newtrainer = await _userManager.FindByNameAsync(User.Identity.Name);
            if (newtrainer != null)
            {
                var appUser = new AppUser
                {
                    TrainerId = newtrainer.TrainerId
                };
            }

            oldtrainer.TrainerId = newtrainer.TrainerId; //Kullanıcın seçtiği Antrenör güncellenerek, kullanıcıya yeni antrenör ataması sağlanacak.

            oldtrainer.Status = true; //Antrenör tarafından seçilen kullanıcının ders istek durumu "Aktif" olacak.

            await _trainingService.UpdateAsync(oldtrainer);
            return RedirectToAction(nameof(Index));
        }

    }
}
