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
            ViewBag.Trainers = await _appuserService.GetAllAsync(); //Tablo'da Antrenörlerin listelenmesi sağlanacak.

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


        [HttpGet]
        public async Task<IActionResult> PersonalTrainingList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = await _trainingService.GetTrainingForTrainerAsync(user.Id);
            return View(value);
        }


        public async Task<IActionResult> TrainingCanceled(int id)
        {
            var oldtrainer = await _trainingService.GetTrainerForTraining(id);
            
            oldtrainer.Status = false; //Kişisel antremanın iptal edilmesi gerçekleşecek ve kullanıcı tekrardan ana sayfada aktif olacak.

            await _trainingService.UpdateAsync(oldtrainer);

            return RedirectToAction(nameof(PersonalTrainingList));

        }


        [HttpGet]
        public async Task<IActionResult> GetUsers(int id)
        {
            await _trainingService.GetAllTrainingAsync();
            var users = await _appuserService.GetByIdAsync(id);
            return View(users);
        }

    }
}
