using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }
    }
}
