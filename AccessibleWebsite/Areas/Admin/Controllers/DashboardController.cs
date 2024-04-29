using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            if (!User.IsInRole("Admin"))
            {
                return NotFound();
            }

            return View();
        }
    }
}
