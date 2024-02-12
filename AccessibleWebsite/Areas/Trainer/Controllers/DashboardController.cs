using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Trainer.Controllers
{
    [Area("Trainer")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
