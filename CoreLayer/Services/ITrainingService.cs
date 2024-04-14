using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
    public interface ITrainingService
    {
        Task<Training> AddTrainingAsync(Training training);
        Task<Training> GetTrainerForTraining(int id);
        Task<IEnumerable<Training>> GetAllTrainingAsync();
        Task UpdateAsync(Training training);
        Task<Training> GetByNewTrainerAsync(int id);
    }
}
