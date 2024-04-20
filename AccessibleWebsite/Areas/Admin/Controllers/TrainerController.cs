using AccessibleWebsite.Models;
using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class TrainerController : Controller
    {

        private readonly IAppUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public TrainerController(IAppUserService userService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult AddTrainer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainer(UserRegisterViewModel ap)
        {
            AppUser appUser = new AppUser
            {
                Name = ap.Name,
                Surname = ap.Surname,
                Email = ap.Email,
                UserName = ap.UserName,
                Branch = ap.Branch
            };

            if (ap.Password == ap.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, ap.Password);

                if (result.Succeeded)
                {
                    if (ap.Branch != null)
                    {

                        appUser.TrainerId = appUser.Id;  // Eğer Branch "null" değilse, TrainerId ataması yapılacak.
                        await _userManager.UpdateAsync(appUser);
                    }
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(ap);
        }


        [HttpGet]
        public async Task<IActionResult> ListTrainers()
        {
            var trainer = await _userService.GetTrainers();

            return View(trainer);
        }


        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var trainer = await _userService.GetByIdAsync(id);
            await _userService.RemoveAsync(trainer);
            return RedirectToAction(nameof(ListTrainers));
        }
    }
}
