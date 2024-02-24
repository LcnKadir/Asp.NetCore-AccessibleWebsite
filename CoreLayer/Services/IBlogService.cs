using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
    public interface IBlogService
    {
        Task<Blog> AddAsync(Blog blog);
        Task RemoveAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task<Blog> GetByIdAsync(int id);
        Task<IEnumerable<Blog>> GetAllAsync();


        Task<Blog> GetDetailsBlogAsync(int id);
        Task<List<Blog>> GetBlogWithTrainer();
        Task<List<Blog>> GetBlogForTrainer(int id);
        Task<List<Blog>> GetLastBlogAsync(int id);
    }
}
