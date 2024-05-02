using AccessibleWebsite.Models;
using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Controllers
{
    public class DefaultController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStoryService _storyService;
        private readonly SignInManager<AppUser> _signInManager;

        public DefaultController(UserManager<AppUser> userManager, IStoryService storyService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _storyService = storyService;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(int id)
        {
            //
            var stories = await _storyService.SelectedStories(id);

            //Üye giriş yaptığı zaman erişilebilir mod için "Sweetalert" ile bir öneri görseli çıkacak.
            if (TempData.ContainsKey("ShowAccessSweetAlert") && (bool)TempData["ShowAccessSweetAlert"])
            {
                ViewData["ShowAccessSweetAlert"] = true;

                //TempData'daki değer temizleyenecek.
                TempData.Remove("ShowAccessSweetAlert");
            }

            return View(stories);
        }

        public async Task<IActionResult> AccessibleMode()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user.Status == true) //Üye statusu true ise false yapılacak ve Default Index'e yönlendirilecek. Böylelikle Üye erişilebilir mod'dan çıkmış olacak.
            {
                user.Status = false;
                await _userManager.UpdateAsync(user);

                return RedirectToAction(nameof(Index));
            }
            if (user.Status == false) //Üye statusu false ise ilgili sayfaya yönlendirilerek, satatusu true yapılacak ve erişilebilir moda giriş yapmış olacak.
            {
                user.Status = true;
                await _userManager.UpdateAsync(user);

                return RedirectToAction("AccessibleMode", "Default", new { area = "Accessible" });
            }
            return View();
        }
    }
}
