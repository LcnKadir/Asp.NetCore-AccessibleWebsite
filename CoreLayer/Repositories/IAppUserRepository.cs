using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repositories
{
    public interface IAppUserRepository
    {
        Task AddAsync(AppUser appUser);
        void Update(AppUser appUser);
        void Remove(AppUser appUser);
        void RemoveRange(IQueryable<AppUser> entities);
        Task<AppUser> GetByIdAsync(int id);
        Task<IEnumerable<AppUser>> GetAllAsync();



        public Task<List<AppUser>> GetTrainers();
        public Task<Blog> GetTrainerAsync(int id);
    }
}
