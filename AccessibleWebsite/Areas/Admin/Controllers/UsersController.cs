using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ServiceLayer.Services;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IAppUserService _appUserService;

        public UsersController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public async Task<IActionResult> ListUsers()
        {
            return View(await _appUserService.GetAllAsync());
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _appUserService.GetByIdAsync(id);
            await _appUserService.RemoveAsync(user);
            return RedirectToAction(nameof(ListUsers));
        }

        public async Task<IActionResult> RestrictUser(int id)
        {
            var user = await _appUserService.GetByIdAsync(id);
            user.Restriction = true;
            await _appUserService.UpdateAsync(user);
            return RedirectToAction(nameof(ListUsers));
        }

        public async Task<IActionResult> RemoveRestriction(int id)
        {
            var user = await _appUserService.GetByIdAsync(id);
            user.Restriction = false;
            await _appUserService.UpdateAsync(user);
            return RedirectToAction(nameof(ListUsers));
        }

    }
}
