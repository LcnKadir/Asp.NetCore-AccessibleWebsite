using AccessibleWebsite.Areas.Member.Models;
using CoreLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Member.Controllers
{
    [Area("Member")]
    public class ProfileController : Controller
    {  

        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(MemberEditViewModel memberEditViewModel)
        {
            var member = await _userManager.FindByNameAsync(User.Identity.Name);

            memberEditViewModel.Name = member.Name;
            memberEditViewModel.Surname = member.Surname;
            memberEditViewModel.Gender = member.Gender;
            memberEditViewModel.Email = member.Email;
            memberEditViewModel.Age = member.Age;

            var val = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.memberName = val.Name + " " + val.Surname;
            ViewBag.UserImage = val.ImageUrl;
            ViewBag.userName = val.UserName;


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
                var savelocation = resource + "/wwwroot/MembersImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await memberModel.Image.CopyToAsync(stream);
                members.ImageUrl = imagename;
            }
            members.Name = memberModel.Name;
            members.Surname = memberModel.Surname;
            members.Description = memberModel.Gender;
            members.Description = memberModel.Age;
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
