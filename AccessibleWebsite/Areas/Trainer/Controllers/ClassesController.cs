using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AccessibleWebsite.Areas.Trainer.Controllers
{
    [Area("Trainer")]
    [Authorize(Roles = "Antrenör")]

    public class ClassesController : Controller
    {
        private readonly IClassService _classService;
        private readonly UserManager<AppUser> _userManager;

        public ClassesController(IClassService classService, UserManager<AppUser> userManager)
        {
            _classService = classService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddClass()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Id = user.Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClass(Class clas)
        {
            if (clas.ImageUrl != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(clas.ImageUrl.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/ClassImage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await clas.ImageUrl.CopyToAsync(stream);
                clas.Image = imagename;
            }

            await _classService.AddAsync(clas);
            return RedirectToAction(nameof(ListClass));
        }

        [HttpGet]
        public async Task<IActionResult> ListClass()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var appUser = new AppUser
                {
                    Id = user.Id
                };

                var value = await _classService.GetClassForTrainer(appUser.Id);
                return View(value);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditClass(int id)
        {
            var value = await _classService.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> EditClass(Class clas)
        {
            if (clas.ImageUrl != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(clas.ImageUrl.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/ClassImage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await clas.ImageUrl.CopyToAsync(stream);
                clas.Image = imagename;
            }
            await _classService.AddAsync(clas);
            return RedirectToAction(nameof(ListClass));
        }

        public async Task<IActionResult> CancelClass(int id)
        {
            var values = await _classService.GetByIdAsync(id);
            values.ClassesStatus = true;
            await _classService.UpdateAsync(values);
            return RedirectToAction(nameof(ListClass));
        }


        public async Task<IActionResult> DeleteClass(int id)
        {
            var value = await _classService.GetByIdAsync(id);
            await _classService.RemoveAsync(value);
            return RedirectToAction(nameof(ListClass));

        }


    }
}
