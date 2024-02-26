using CoreLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Controllers
{
    public class DefaultController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DefaultController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
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
