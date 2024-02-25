using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Accessible
{
    public class _AccessibleClasses: ViewComponent
    {
        private readonly IClassService _classService;

        public _AccessibleClasses(IClassService classService)
        {
            _classService = classService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value = await _classService.GetLastClasses(id);
            return View(value);
        }
    }
}
