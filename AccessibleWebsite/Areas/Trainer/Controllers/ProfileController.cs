using AccessibleWebsite.Areas.Member.Models;
using AccessibleWebsite.Areas.Trainer.Models;
using CoreLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Trainer.Controllers
{
    [Area("Trainer")]
    public class ProfileController : Controller
    {
         private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            MemberEditViewModel userEditViewModel = new();
            userEditViewModel.Name = values.Name;
            userEditViewModel.Surname = values.Surname;
            userEditViewModel.Email = values.Email;
            userEditViewModel.Description = values.Description;
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(MemberEditViewModel trainer)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (trainer.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(trainer.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/TrainersImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await trainer.Image.CopyToAsync(stream);
                user.ImageUrl = imagename;
            }
            user.Name = trainer.Name;
            user.Surname = trainer.Surname;
            user.Description = trainer.Description;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, trainer.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
