using CoreLayer.Models;
using CoreLayer.Repositories;
using CoreLayer.Services;
using CoreLayer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClassService(IClassRepository classRepository, IUnitOfWork unitOfWork)
        {
            _classRepository = classRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Class> AddAsync(Class clas)
        {
            await _classRepository.AddAsync(clas);
            await _unitOfWork.CommitAsync();
            return clas;
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await _classRepository.GetAllAsync();
        }

        public async Task<Class> GetByIdAsync(int id)
        {
            return await _classRepository.GetByIdAsync(id);
        }

        public async Task<Class> GetClassAsync()
        {
            return await _classRepository.GetClassAsync();
        }

        public async Task<List<Class>> GetClassForTrainer(int id)
        {
            return await _classRepository.GetClassForTrainer(id);
        }

        public async Task<List<Class>> GetClassWithTrainer()
        {
            return await _classRepository.GetClassWithTrainer();
        }

        public async Task RemoveAsync(Class clas)
        {
            _classRepository.Remove(clas);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Class clas)
        {
            _classRepository.Update(clas);
            await _unitOfWork.CommitAsync();
        }
    }
}
