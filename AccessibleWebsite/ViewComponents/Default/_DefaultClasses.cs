using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Default
{
    public class _DefaultClasses : ViewComponent
    {
        private readonly IClassService _classService;

        public _DefaultClasses(IClassService classService)
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
