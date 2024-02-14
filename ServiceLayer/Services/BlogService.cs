using CoreLayer.Models;
using CoreLayer.Repositories;
using CoreLayer.Services;
using CoreLayer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IBlogRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Blog> AddAsync(Blog blog)
        {
            await _repository.AddAsync(blog);
            await _unitOfWork.CommitAsync();
            return blog;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Blog> GetBlogAsync(int id)
        {
            return await _repository.GetBlogAsync(id);
        }

        public async Task<List<Blog>> GetBlogForTrainer(int id)
        { 
            return await _repository.GetBlogForTrainer(id);
        }

        public async Task<List<Blog>> GetBlogWithTrainer()
        {
            return await _repository.GetBlogWithTrainer();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Blog blog)
        {
            _repository.Remove(blog);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Blog blog)
        {
            _repository.Update(blog);
            await _unitOfWork.CommitAsync();
        }
    }
}
