using AccessibleWebsite.Areas.Admin.Models;
using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
        public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserService;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IAppUserService appUserService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            AppRole role = new AppRole()
            {
                Name = createRoleViewModel.RoleName
            };

            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();

            }
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
            {
                RoleId = value.Id,
                RoleName = value.Name
            };
            return View(updateRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleViewModel.RoleId);
            value.Name = updateRoleViewModel.RoleName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> UsersList()
        {
            var users = await _appUserService.GetAllAsync();
            ViewBag.Roles = _userManager.Users.ToList();
            return View(users);
        }


        [HttpGet]
        public async Task<IActionResult> RoleReplacement(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["UserId"] = user.Id;

            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleReplacementViewModel> roleReplacementViewModels = new();
            foreach (var item in roles)
            {
                RoleReplacementViewModel model = new();
                model.RoleId = item.Id;
                model.RoleName = item.Name;
                model.RoleExist = userRoles.Contains(item.Name);
                roleReplacementViewModels.Add(model);
            }
            return View(roleReplacementViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> RoleReplacement(List<RoleReplacementViewModel> model)
        {
            var userId = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in model)
            {
                if (item.RoleExist)

                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);

                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }

            }
            return RedirectToAction(nameof(UsersList));

        }
    }
}
