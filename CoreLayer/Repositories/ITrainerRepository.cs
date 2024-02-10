using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repositories
{
    public interface ITrainerRepository
    {
        Task AddAsync(Trainer trainer);
        void Update(Trainer trainer);
        void Remove(Trainer trainer);
        void RemoveRange(IQueryable<Trainer> entities);
        Task<Trainer> GetByIdAsync(int id);
        Task<IEnumerable<Trainer>> GetAllAsync();
    }
}
