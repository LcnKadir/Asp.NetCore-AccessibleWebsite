using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Member.Controllers
{
	[Area("Member")]
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;
		private readonly UserManager<AppUser> _userService;
		private readonly IBlogService _blogService;

		public CommentController(ICommentService commentService, UserManager<AppUser> userService, IBlogService blogService)
		{
			_commentService = commentService;
			_userService = userService;
			_blogService = blogService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var user = await _userService.FindByNameAsync(User.Identity.Name);
			var comment = await _commentService.GetCommentWithBlogList(user.Id);
			return View(comment);
		}

		[HttpGet]
		public async Task<IActionResult> EditComment(int id)
		{
			var user = await _commentService.GetByIdAsync(id);
			return View(user);
		}


		[HttpPost]
		public async Task<IActionResult> EditComment(Comment comment, int id)
		{
			await _commentService.UpdateAsync(comment);
			return RedirectToAction(nameof(Index));
		}



		public async Task<IActionResult> DeleteComment(int id)
		{

			var user = await _commentService.GetByIdAsync(id);
			await _commentService.RemoveAsync(user);
			return RedirectToAction(nameof(Index));
		}


	}
}
