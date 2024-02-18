using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Controllers
{
    [AllowAnonymous]
    public class ClassesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
