using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Trainer
{
    public class _TrainerDashboardClasses : ViewComponent
    {

        private readonly IClassService _classService;

        public _TrainerDashboardClasses(IClassService classService)
        {
            _classService = classService;
        }


        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value = await _classService.GetLastClassesForDashboard(id);
            return View(value);
        }
    }
}
