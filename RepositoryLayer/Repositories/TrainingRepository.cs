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
    public class TrainingRepository : ITrainingRepository
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<Training> _DbSet;

        public TrainingRepository(AppDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Training>();
        }

        public async Task AddTrainingAsync(Training training)
        {
            await _DbSet.AddAsync(training);
        }

        public async Task<Training> GetTrainerForTraining(int id)
        {
            return await _context.Trainings.Include(x => x.AppUser).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
