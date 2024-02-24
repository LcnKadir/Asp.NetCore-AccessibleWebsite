using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
    public interface IAppUserService
    {
        Task<AppUser> AddAsync(AppUser appUser);
        Task RemoveAsync(AppUser appUser);
        Task UpdateAsync(AppUser appUser);
        Task<AppUser> GetByIdAsync(int id);
        Task<IEnumerable<AppUser>> GetAllAsync();


        Task<List<AppUser>> GetTrainers();
        Task<List<AppUser>> GetLastTrainersAsync(int id);

    }
}
