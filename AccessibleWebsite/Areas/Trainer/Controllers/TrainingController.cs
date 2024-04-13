using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Trainer.Controllers
{
    public class TrainingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
