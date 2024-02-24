using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repositories
{
    public interface ITrainingRepository
    {
        Task AddTrainingAsync(Training training);

        Task<Training> GetTrainerForTraining(int id);

    }
}
