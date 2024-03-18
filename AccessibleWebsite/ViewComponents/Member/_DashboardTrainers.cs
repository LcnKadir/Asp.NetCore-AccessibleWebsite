using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Member
{
    public class _DashboardTrainers: ViewComponent
    {
        private readonly IAppUserService _userService;

        public _DashboardTrainers(IAppUserService userService)
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
