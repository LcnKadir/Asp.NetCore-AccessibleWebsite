using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
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
    }
}
