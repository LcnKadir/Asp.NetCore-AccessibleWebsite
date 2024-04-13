﻿using CoreLayer.Models;
using CoreLayer.Repositories;
using CoreLayer.Services;
using CoreLayer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TrainingService(ITrainingRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Training> AddTrainingAsync(Training training)
        {
            await _repository.AddTrainingAsync(training);
            await _unitOfWork.CommitAsync();
            return training;
        }

        public async Task<IEnumerable<Training>> GetAllTrainingAsync()
        {
            return await _repository.GetAllTrainingAsync();
        }

        public async Task<Training> GetTrainerForTraining(int id)
        {
            return await _repository.GetTrainerForTraining(id);
        }
    }
}
