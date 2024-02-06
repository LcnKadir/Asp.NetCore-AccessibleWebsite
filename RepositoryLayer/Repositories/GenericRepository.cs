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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _Context;
        private readonly DbSet<T> _DbSet;

        public GenericRepository(DbContext Context)
        {
            _Context = Context;
            _DbSet = _Context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _DbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _DbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
           return await _DbSet.AnyAsync(expression);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public  void Remove(T entity)
        {
           _DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
           _DbSet.Update(entity);
        }

        public  IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _DbSet.Where(expression);
        }
    }
}
