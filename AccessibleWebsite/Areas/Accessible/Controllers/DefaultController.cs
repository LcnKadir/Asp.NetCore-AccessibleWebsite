using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Accessible.Controllers
{
    [Area("Accessible")]
    public class DefaultController : Controller
    {
        public IActionResult AccessibleMode()
        {
            return View();
        }
    }
}
