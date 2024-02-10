using CoreLayer.Models;
using CoreLayer.Repositories;
using CoreLayer.Services;
using CoreLayer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class AccessibleUserService : IAccessibleUserService
    {
        private readonly IAccessibleUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AccessibleUserService(IAccessibleUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AccessibleUser> AddAsync(AccessibleUser accessibleUser)
        {
            await _repository.AddAsync(accessibleUser);
            await _unitOfWork.CommitAsync();
            return accessibleUser;
        }

        public async Task<IEnumerable<AccessibleUser>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AccessibleUser> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(AccessibleUser accessibleUser)
        {
            _repository.Remove(accessibleUser);
            await _unitOfWork.CommitAsync();
        }

        public  async Task UpdateAsync(AccessibleUser accessibleUser)
        {
            _repository.Update(accessibleUser);
            await _unitOfWork.CommitAsync();
        }
    }
}
