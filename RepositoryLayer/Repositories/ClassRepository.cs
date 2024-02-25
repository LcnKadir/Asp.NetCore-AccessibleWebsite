using CoreLayer.Models;
using CoreLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Class> _DbSet;

        public ClassRepository(AppDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Class>();
        }

        public async Task AddAsync(Class clas)
        {
            await _DbSet.AddAsync(clas);
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<Class> GetByIdAsync(int id)
        {
           return await _DbSet.FindAsync(id);
        }

        public async Task<Class> GetClassAsync()
        {
            return await _context.Classes.Include(x => x.AppUser).FirstOrDefaultAsync();
        }

        public async Task<List<Class>> GetClassForTrainer(int id)
        {
            return await _context.Classes.Include(x => x.AppUser).Where(x => x.AppUserId == id).ToListAsync();
        }

        public async Task<IEnumerable<Class>> GetClassIdAsync(int id)
        {
            return await _context.Classes.Include(x => x.AppUser).Include(x => x.Messages).Where(x=> x.Id == id).ToListAsync();
        }

        public async Task<List<Class>> GetClassWithTrainer()
        {
            return await _context.Classes.Include(X => X.AppUser).OrderByDescending(x => x.CreateDate).ToListAsync();
        }

        public async Task<List<Class>> GetLastClasses(int id)
        {
            return await _context.Classes.Include(x=> x.AppUser).OrderByDescending(x => x.Id).Take(12).ToListAsync();
        }

        public void Remove(Class clas)
        {
            _DbSet.Remove(clas);
        }

        public void RemoveRange(IQueryable<Class> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void Update(Class clas)
        {
            _DbSet.Update(clas);
        }
    }
}
