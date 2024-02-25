using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Accessible
{
    public class _AccessibleTrainers: ViewComponent
    {
        private readonly IAppUserService _userService;

        public _AccessibleTrainers(IAppUserService userService)
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
