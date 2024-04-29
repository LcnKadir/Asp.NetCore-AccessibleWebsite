using AccessibleWebsite.Areas.Member.Models;
using CoreLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]

    public class ProfileController : Controller
    {  

        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            MemberEditViewModel memberEditViewModel = new ();

            memberEditViewModel.Name = user.Name;
            memberEditViewModel.Surname = user.Surname;
            memberEditViewModel.Email = user.Email;
            memberEditViewModel.ImageUrl = user.ImageUrl;
            return View(memberEditViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Index(MemberEditViewModel memberModel)
        {
            var members = await _userManager.FindByNameAsync(User.Identity.Name);
            if (memberModel.Image != null)

            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(memberModel.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/MemberImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await memberModel.Image.CopyToAsync(stream);
                members.ImageUrl = imagename;
            }
            members.Name = memberModel.Name;
            members.Surname = memberModel.Surname;
            members.Gender = memberModel.Gender;
            members.Age = memberModel.Age;
            members.Height = memberModel.Height;
            members.Kilo = memberModel.Kilo;
            members.PasswordHash = _userManager.PasswordHasher.HashPassword(members, memberModel.Password);
            var result = await _userManager.UpdateAsync(members);
            if (result.Succeeded)
            {
                return RedirectToAction("Register", "Login");
            }
            return View();
        }
    }
}
