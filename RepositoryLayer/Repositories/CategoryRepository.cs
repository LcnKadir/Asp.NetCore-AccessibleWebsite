using CoreLayer.Models;
using CoreLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<Category> _DbSet;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Category>();
        }

        public async Task AddAsync(Category category)
        {
            await _DbSet.AddAsync(category);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public async Task<Category> GetCategoryDetailsAsync(int id)
        {
            return await _context.Categories.Where(x => x.Id == id).Select(c => new Category{Id = c.Id,Name = c.Name,Blogs = c.Blogs.Select(b => new Blog { Id = b.Id}).ToList()}).FirstOrDefaultAsync();
        }
    }
}
