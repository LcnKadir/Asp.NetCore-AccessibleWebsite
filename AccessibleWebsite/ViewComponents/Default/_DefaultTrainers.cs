using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Default
{
    public class _DefaultTrainers : ViewComponent
    {
        private readonly IAppUserService _userService;

        public _DefaultTrainers(IAppUserService userService)
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
