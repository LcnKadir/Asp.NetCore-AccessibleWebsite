using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Trainer.Controllers
{
    [Area("Trainer")]

    public class ClassesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
