using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
    public interface ICategoryService
    {
        Task<Category> AddAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetCategoryDetailsAsync(int id);
        Task<Category> GetByIdAsync(int id);
    }
}
