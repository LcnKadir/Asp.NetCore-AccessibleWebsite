﻿using AccessibleWebsite.Models;
using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Services;

namespace AccessibleWebsite.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IClassService _classService;
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public ClassesController(IClassService classService, IMessageService messageService, UserManager<AppUser> userManager)
        {
            _classService = classService;
            _messageService = messageService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var getclass = await _classService.GetClassWithTrainer(); //Derslerin sayfada listelenmesi.

            var classes = await _classService.GetAllAsync();
            var days = await _classService.GetAllAsync();
            await _messageService.GetAllMessageAsync();

            ViewBag.Classes = classes;
            ViewBag.Days = days;

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (values.EmailConfirmed == true)
            {
                return View(getclass);
            }
            if (values.EmailConfirmed == false && values.TrainerId != null)
            {
                return View(getclass);
            }
            if (values.EmailConfirmed == false || values.EmailConfirmed == null || values.Branch == null)//Mail adresini doğrulamayan üye dersleri göremeyecek.
            {
                return RedirectToAction("Index", "ConfirmMail");
            }

            return View(getclass);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RegisterClass(Message msg, List<int> clasId) //Ders kaydı.
        {
            msg.ClassRegistering = true;
            await _messageService.AddAsync(msg);
            return RedirectToAction("Index", "Classes", new { id = clasId });

        }


    }
}
