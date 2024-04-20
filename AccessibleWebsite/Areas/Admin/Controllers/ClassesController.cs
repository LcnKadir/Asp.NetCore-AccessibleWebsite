using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    public class ClassesController : Controller
    {
        public IActionResult ListClasses()
        {
            return View();
        }
    }
}
