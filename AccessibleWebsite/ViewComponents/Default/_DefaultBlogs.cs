﻿using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.ViewComponents.Default
{
    public class _DefaultBlogs : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public _DefaultBlogs(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;

        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _blogService.GetLastBlogAsync(id);
            await _categoryService.GetAllAsync();
            return View(values);

        }
    }
}
