using CoreLayer.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repositories
{
    public interface IBlogRepository
    {
        Task AddAsync(Blog blog);
        void Update(Blog blog);
        void Remove(Blog blog);
        void RemoveRange(IQueryable<Blog> entities);
        Task<Blog> GetByIdAsync(int id);
        Task<IEnumerable<Blog>> GetAllAsync();
        

        Task<Blog> GetDetailsBlogAsync(int id); 
        Task<List<Blog>> GetBlogWithTrainer();
        Task<List<Blog>> GetBlogForTrainer(int id);
        Task<List<Blog>> GetLastBlogAsync(int id); 
    }
}
