using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace AccessibleWebsite.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult BlogDetails()
        {
            return View();
        }


  
    }
}
