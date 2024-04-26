using CoreLayer.Models;
using CoreLayer.Repositories;
using CoreLayer.Services;
using CoreLayer.UnitOfWorks;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StoryService(IStoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Story> AddStoryAsync(Story story)
        {
            await _repository.AddStoryAsync(story);
            await _unitOfWork.CommitAsync();
            return story;
        }

        public async Task<IEnumerable<Story>> GetAllStoryAsync()
        {
           return await _repository.GetAllStoryAsync();
        }

        public async Task RemoveAsync(Story story)
        {
            _repository.RemoveAsync(story);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Story story)
        {
            _repository.UpdateAsync(story);
            await _unitOfWork.CommitAsync();
        }
    }
}
