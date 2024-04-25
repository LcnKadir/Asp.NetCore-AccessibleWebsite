using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userService;

        public CommentController(ICommentService commentService, UserManager<AppUser> userService)
        {
            _commentService = commentService;
            _userService = userService;
        }

        public async  Task<IActionResult> GetUsersComment()
        {
            var user = await _userService.FindByNameAsync(User.Identity.Name);
            var comment = await _commentService.GetCommentWithBlogList(user.Id);
            return View(comment);
        }
    }
}
