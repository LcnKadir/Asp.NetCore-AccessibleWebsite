﻿using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserHistoryController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IAppUserService _appUserService;

        public UserHistoryController(ICommentService commentService, IAppUserService appUserService)
        {
            _commentService = commentService;
            _appUserService = appUserService;
        }

        public async Task<IActionResult> GetUsersComment(int userId)
        {
            var user = await _appUserService.GetByIdAsync(userId);
            var comments = await _commentService.GetCommentWithBlogList(user.Id);
                      
            return View(comments);
        }
    }
}
