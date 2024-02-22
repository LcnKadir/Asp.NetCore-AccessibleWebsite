using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AccessibleWebsite.Controllers
{

    public class TrainersController : Controller
    {
        private readonly IAppUserService _userService;

        public TrainersController(IAppUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetTrainers();
            return View(values);
        }

    }
}
