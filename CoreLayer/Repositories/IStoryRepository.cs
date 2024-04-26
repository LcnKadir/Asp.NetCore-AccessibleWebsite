using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repositories
{
    public interface IStoryRepository
    {
        Task AddStoryAsync(Story story);
        Task<IEnumerable<Story>> GetAllStoryAsync();
        void UpdateAsync(Story story);
        void RemoveAsync(Story story);
    }
}
