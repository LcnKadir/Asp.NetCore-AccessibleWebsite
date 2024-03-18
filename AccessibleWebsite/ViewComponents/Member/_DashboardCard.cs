using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Member
{
    public class _DashboardCard: ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _DashboardCard(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = user.Name + " " + user.Surname;
            return View();

        }
    }
}
