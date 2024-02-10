using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
    public interface ITrainerService
    {
        Task<Trainer> AddAsync(Trainer trainer);
        Task RemoveAsync(Trainer trainer);
        Task UpdateAsync(Trainer trainer);
        Task<Trainer> GetByIdAsync(int id);
        Task<IEnumerable<Trainer>> GetAllAsync();
        
    }
}
