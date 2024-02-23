﻿using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
    public interface ITrainingService
    {
        Task<Training> AddTrainingAsync(Training training);
        public Task<Training> GetTrainerForTraining(int id);
    }
}