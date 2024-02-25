using CoreLayer.Models;
using CoreLayer.Repositories;
using Microsoft.AspNetCore.Identity;
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
        private readonly AppDbContext _context;
        private readonly DbSet<AppUser> _DbSet;
        private readonly UserManager<AppUser> _userManager;

        public AppUserRepository(AppDbContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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

        public async Task<List<AppUser>> GetLastTrainersAsync(int id)
        {
            return await _context.AppUsers.OrderByDescending(x => x.Id).Take(3).ToListAsync();
        }

        public async Task<List<AppUser>> GetTrainers()

        {
            return await _userManager.Users.Where(x => x.Id == x.TrainerId).ToListAsync();
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
