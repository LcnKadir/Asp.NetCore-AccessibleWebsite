using CoreLayer.Models;
using CoreLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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


        public async Task<List<Blog>> GetBlogForTrainer(int id) 
        {
            return await _context.Blogs.Include(x => x.AppUser).Where(x => x.AppUserId == id).ToListAsync();
        }

        public async Task<List<Blog>> GetBlogWithTrainer()
        {
            return await _context.Blogs.Include(X => X.AppUser).OrderByDescending(x => x.CreateDate).ToListAsync();
        }


        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public async Task<Blog> GetDetailsBlogAsync(int id)
        {
            return await _context.Blogs.Include(x => x.AppUser).Include(x => x.Comments).ThenInclude(x=> x.AppUser).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Blog>> GetLastBlogAsync(int id)
        {
           return await _context.Blogs.OrderByDescending(x=> x.Id).Take(3).ToListAsync();
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
