using CoreLayer.Models;
using CoreLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
		protected readonly AppDbContext _context;
        private readonly DbSet<Trainer> _DbSet;

        public TrainerRepository(AppDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Trainer>();
        }

        public async Task AddAsync(Trainer trainer)
        {
            await _DbSet.AddAsync(trainer);
        }

        public async Task<IEnumerable<Trainer>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<Trainer> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public void Remove(Trainer trainer)
        {
            _DbSet.Remove(trainer);
        }

        public void RemoveRange(IQueryable<Trainer> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void Update(Trainer trainer)
        {
            _DbSet.Update(trainer);
        }
    }
}
