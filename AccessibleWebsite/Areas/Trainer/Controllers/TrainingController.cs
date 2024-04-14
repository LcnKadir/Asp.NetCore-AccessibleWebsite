﻿using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ServiceLayer.Services;

namespace AccessibleWebsite.Areas.Trainer.Controllers
{
    [Area("Trainer")]

    public class TrainingController : Controller
    {
       private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        public async Task<IActionResult> Index()
        {

            return View( await _trainingService.GetAllTrainingAsync());
        }


    }
}
