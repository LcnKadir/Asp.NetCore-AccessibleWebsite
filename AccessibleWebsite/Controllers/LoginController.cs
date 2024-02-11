using AccessibleWebsite.Models;
using CoreLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AccessibleWebsite.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		//Kullanıcının kayıt olma ve giriş yapma işlemleri, tek bir controller'da birleştirildi.

		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
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

			if (ap.Password == ap.ConfirmPassword)
			{
				var result = await _userManager.CreateAsync(appUser, ap.Password);
				if (result.Succeeded)
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



		[HttpGet]
		public IActionResult SignIn()
		{
			return View();

		}

		[HttpPost]
		public async Task<IActionResult> SignIn(UserSignInViewModel user)
		{

			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, true); // ilk "true" ile kullanıcı sistemde hatırlanacak, ikinci "t" ile de şifre beş defa yanlış girildiği taktirde kullanıcı bloklanacak.
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Default");
				}
				else
				{
					return RedirectToAction("SignIn", "SignIn");
				}

			}
			return View();
		}
	}
}
