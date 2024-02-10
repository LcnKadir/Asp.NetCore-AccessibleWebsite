using CoreLayer.Models;
using CoreLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class BlogRepository : IBlogRepository
    {
		protected readonly AppDbContext _context;
        private readonly DbSet<Blog> _DbSet;

        public BlogRepository(AppDbContext context)
        {
			_context = context;
            _DbSet = context.Set<Blog>();
        }

        public async Task AddAsync(Blog blog)
        {
            await _DbSet.AddAsync(blog);
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public void Remove(Blog blog)
        {
            _DbSet.Remove(blog);
        }

        public void RemoveRange(IQueryable<Blog> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void Update(Blog blog)
        {
            _DbSet.Update(blog);
        }
    }
}
