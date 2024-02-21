using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
