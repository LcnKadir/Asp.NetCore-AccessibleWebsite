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

        public DefaultController(UserManager<AppUser> userManager, IStoryService storyService)
        {
            _userManager = userManager;
            _storyService = storyService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var stories = await _storyService.SelectedStories(id);
            return View(stories);
        }

        public async Task<IActionResult> AccessibleMode()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user.Status == true) //Kullanıcı statusu true ise false yapılacak ve Default Index'e yönlendirilecek. Böylelikle kullanıcı erişilebilir mod'dan çıkmış olacak.
            {
                user.Status = false;
                await _userManager.UpdateAsync(user);

                return RedirectToAction(nameof(Index));
            }
            if (user.Status == false) //Kullanıcı statusu false ise ilgili sayfaya yönlendirilerek, satatusu true yapılacak ve erişilebilir moda giriş yapmış olacak.
            {
                user.Status = true;
                await _userManager.UpdateAsync(user);

                return RedirectToAction("AccessibleMode", "Default", new { area = "Accessible" });
            }
            return View();
        }
    }
}
