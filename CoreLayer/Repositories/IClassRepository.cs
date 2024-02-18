using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repositories
{
    public interface IClassRepository
    {
        Task AddAsync(Class clas);
        void Update(Class clas);
        void Remove(Class clas);
        void RemoveRange(IQueryable<Class> entities);
        Task<Class> GetByIdAsync(int id);
        Task<IEnumerable<Class>> GetAllAsync();


        public Task<Class> GetClassAsync();
        public Task<List<Class>> GetClassWithTrainer();
        public Task<List<Class>> GetClassForTrainer(int id);
    }
}
