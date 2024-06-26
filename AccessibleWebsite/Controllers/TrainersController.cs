﻿using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace AccessibleWebsite.Controllers
{

    public class TrainersController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly ITrainingService _trainingService;
        private readonly UserManager<AppUser> _userManager;

        public TrainersController(IAppUserService userService, ITrainingService trainingService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _trainingService = trainingService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index() //Tüm Trainer'lar listenecek.
        {
            var appUsers = await _userService.GetTrainers();
            return View(appUsers);
        }


        [HttpGet]
        public async Task<IActionResult> GetTraining(int id) //Antreman yapmak istenilen Trainer'a gidilecek.
        {
            await _trainingService.GetAllTrainingAsync();
            var trainer = await _userManager.Users.Where(x => x.TrainerId == id).FirstOrDefaultAsync();
            return View(trainer);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTraining(Training training)
        {
            training.CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            await _trainingService.AddTrainingAsync(training);
            return RedirectToAction(nameof(Index));
        }
    }
}
