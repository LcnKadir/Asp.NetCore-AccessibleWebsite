using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserHistoryController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IAppUserService _appUserService;


        public UserHistoryController(ICommentService commentService, IAppUserService appUserService)
        {
            _commentService = commentService;
            _appUserService = appUserService;
        }

        public async Task<IActionResult> Index(int userId)
        {
            var user = await _appUserService.GetByIdAsync(userId);
            var comments = await _commentService.GetCommentWithBlogList(user.Id);

            ViewBag.User = userId; //Kullanıcının seçtiği haftalık dersi listelenmek için Id'si alındı.

            ViewBag.UserName = await _appUserService.GetAllAsync(); //Hareket geçmişinde kullanıcı bilgileri listelendi.

            return View(comments);
        }
    }
}
