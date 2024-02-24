using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
