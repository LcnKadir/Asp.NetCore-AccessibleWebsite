﻿using CoreLayer.Models;
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
    public class AppUserRepository : IAppUserRepository
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<AppUser> _DbSet;

        public AppUserRepository(AppDbContext context)
        {
			_context = context;
            _DbSet = context.Set<AppUser>();
        }

        public async Task AddAsync(AppUser appUser)
        {
            await _DbSet.AddAsync(appUser);
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<AppUser> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public void Remove(AppUser appUser)
        {
            _DbSet.Remove(appUser);
        }

        public void RemoveRange(IQueryable<AppUser> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void Update(AppUser appUser)
        {
            _DbSet.Update(appUser);
        }
    }
}
