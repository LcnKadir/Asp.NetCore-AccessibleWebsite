using AccessibleWebsite.Models;
using CoreLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(ConfirmViewModel mailConfirmViewModel)
        {

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.mail = user.Email;

                if (user.EmailConfirmed == true)
                {
                    return View();
                }

                if (mailConfirmViewModel.ConfrimCode == user.ConfirmCode)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                    return View();
                }
                else
                {
                    return View();
                }

            }
            return RedirectToAction("Index", "Default");



        }



    }
}

