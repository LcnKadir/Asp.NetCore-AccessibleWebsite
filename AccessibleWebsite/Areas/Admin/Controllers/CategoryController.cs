﻿using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessibleWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller 
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.GetAllAsync();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> CreateBranch()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch(Category category)
        {
            await _categoryService.AddAsync(category);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteBranch(int id)
        {
            var branch = await _categoryService.GetByIdAsync(id);
            await _categoryService.RemoveAsync(branch);
            return RedirectToAction(nameof(Index));
        }

    }
}
