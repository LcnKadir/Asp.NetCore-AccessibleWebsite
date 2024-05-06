using CoreLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Accessible.Controllers
{
    [Area("Accessible")]
    public class DefaultController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DefaultController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

 
        public async Task<IActionResult> AccessibleMode()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user.Status == null)
            {
                user.Status = true; // Kullanıcının statüsünü true olarak güncellenecek ve erişilebilir sayfaya yönlendirilecek.
                await _userManager.UpdateAsync(user);
                return View();
            }
            if (user.Status == true) //Kullanıcı statusu true ise false yapılacak ve Default Index'e yönlendirilecek. Böylelikle kullanıcı erişilebilir mod'dan çıkmış olacak.
            {
                user.Status = false; 
                await _userManager.UpdateAsync(user);

               RedirectToAction("Index", "Default");
            }
            if (user.Status == false) //Kullanıcı statusu true ise false yapılacak ve Default Index'e yönlendirilecek. Böylelikle kullanıcı erişilebilir mod'dan çıkmış olacak.
            {
                user.Status = true;
                await _userManager.UpdateAsync(user);

              return View();
            }

            return View();
        }
    }




}
