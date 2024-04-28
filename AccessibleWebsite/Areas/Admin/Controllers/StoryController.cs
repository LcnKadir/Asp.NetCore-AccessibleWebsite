using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
