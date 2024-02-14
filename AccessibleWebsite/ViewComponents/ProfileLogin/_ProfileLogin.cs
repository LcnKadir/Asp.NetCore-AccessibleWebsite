using CoreLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.ProfileLogin
{
    public class _ProfileLogin : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileLogin(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> Invoke()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity?.Name);
                return View(user);
            }
            return View();
        }
    }

}

