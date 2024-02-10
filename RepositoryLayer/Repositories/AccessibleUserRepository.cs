using CoreLayer.Models;
using CoreLayer.Repositories;
using CoreLayer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class AccessibleUserRepository: IAccessibleUserRepository
    {
		//Protected, projenin ileriki dönemlerinde sınıflara daha detaylı işlemler yapabilmemize olanak sağlamak içindir.
		
        protected readonly AppDbContext _context;
        private readonly DbSet<AccessibleUser> _DbSet;

        public AccessibleUserRepository(AppDbContext context)
        {
			_context = context;
            _DbSet = _context.Set<AccessibleUser>();
        }

        public async Task AddAsync(AccessibleUser accessibleUser)
        {
            await _DbSet.AddAsync(accessibleUser);
        }

        public async Task<IEnumerable<AccessibleUser>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<AccessibleUser> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public void Remove(AccessibleUser accessibleUser)
        {
            _DbSet.Remove(accessibleUser);
        }

        public void RemoveRange(IQueryable<AccessibleUser> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void Update(AccessibleUser accessibleUser)
        {
            _DbSet.Update(accessibleUser);
        }
    }
}
