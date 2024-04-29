using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]

    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
