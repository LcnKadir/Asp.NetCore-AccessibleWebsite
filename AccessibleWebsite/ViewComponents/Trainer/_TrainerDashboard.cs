using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Trainer
{
    public class _TrainerDashboard : ViewComponent
    {
        private readonly IAppUserService _userService;

        public _TrainerDashboard(IAppUserService userService)
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
