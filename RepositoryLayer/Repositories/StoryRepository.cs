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
    public class StoryRepository : IStoryRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Story> _DbSet;

        public StoryRepository(AppDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Story>();
        }

        public async Task AddStoryAsync(Story story)
        {
            await _DbSet.AddAsync(story);
        }

        public async Task<IEnumerable<Story>> GetAllStoryAsync()
        {
            return await _context.Stories.Include(x => x.AppUser).ToListAsync();
        }

        public async Task<Story> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public void RemoveAsync(Story story)
        {
            _DbSet.Remove(story);
        }

        public async Task<List<Story>> SelectedStories(int id)
        {
            return await _context.Stories.Include(x => x.Published == true).OrderByDescending(x => x.Id).Take(5).ToListAsync();
        }

        public void UpdateAsync(Story story)
        {
            _DbSet.Update(story);
        }
    }
}
