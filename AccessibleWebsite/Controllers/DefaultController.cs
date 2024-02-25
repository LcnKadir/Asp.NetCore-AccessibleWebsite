using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Controllers
{
    public class DefaultController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessibleMode() //Erişilebilir mod sayfası.
        {
            return View();
        }
    }
}
