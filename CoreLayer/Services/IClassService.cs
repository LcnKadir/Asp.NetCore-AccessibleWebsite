using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
    public interface IClassService
    {
        Task<Class> AddAsync(Class clas);
        Task RemoveAsync(Class clas);
        Task UpdateAsync(Class clas);
        Task<Class> GetByIdAsync(int id);
        Task<IEnumerable<Class>> GetAllAsync();

        public Task<Class> GetClassAsync();
        public Task<List<Class>> GetClassWithTrainer();
        public Task<List<Class>> GetClassForTrainer(int id);

        Task<IEnumerable<Class>> GetClassIdAsync(int id);
    }
}
