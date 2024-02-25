using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboradController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
