using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Admin
{
    public class _LastTrainerDashboard : ViewComponent
    {
        private readonly IAppUserService _userService;

        public _LastTrainerDashboard(IAppUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _userService.GetLastTrainersAsync(id);
            return View(values);

        }
    }
}
