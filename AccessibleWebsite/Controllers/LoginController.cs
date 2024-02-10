using AccessibleWebsite.Models;
using CoreLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

		public LoginController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel ap)
        {
            AppUser appUser = new AppUser
            {
                Name = ap.Name,
                Surname = ap.Surname,
                Email = ap.Email,
                UserName = ap.UserName,
            };

            if(ap.Password == ap.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, ap.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("SignIn");
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
    }
}
