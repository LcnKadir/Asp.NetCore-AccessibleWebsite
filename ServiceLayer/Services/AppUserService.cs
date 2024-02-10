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
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AppUserService(IAppUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AppUser> AddAsync(AppUser appUser)
        {
            await _repository.AddAsync(appUser);
            await _unitOfWork.CommitAsync();
            return appUser;
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AppUser> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(AppUser appUser)
        {
            _repository.Remove(appUser);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(AppUser appUser)
        {
            _repository.Update(appUser);
            await _unitOfWork.CommitAsync();
        }
    }
}
