using CoreLayer.Models;
using CoreLayer.Repositories;
using CoreLayer.Services;
using CoreLayer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TrainerService(ITrainerRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Trainer> AddAsync(Trainer trainer)
        {
            await _repository.AddAsync(trainer);
            await _unitOfWork.CommitAsync();
            return trainer;
        }

        public async Task<IEnumerable<Trainer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Trainer> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public  async Task RemoveAsync(Trainer trainer)
        {
            _repository.Remove(trainer);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Trainer trainer)
        {
            _repository.Update(trainer);
            await _unitOfWork.CommitAsync();
        }
    }
}
