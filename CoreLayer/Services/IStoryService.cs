using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
    public interface IStoryService
    {
        Task AddStoryAsync(Story story);
        Task<IEnumerable<Story>> GetAllStoryAsync();
        Task UpdateAsync(Story story);
        Task RemoveAsync(Story story);
    }
}
