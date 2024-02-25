using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetCategoryDetailsAsync(int id);
        Task<Category> GetByIdAsync(int id);
    }
}
