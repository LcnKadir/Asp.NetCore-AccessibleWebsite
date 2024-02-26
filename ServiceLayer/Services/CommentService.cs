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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository  _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Comment> AddAsync(Comment comment)
        {
            await _repository.AddAsync(comment);
            await _unitOfWork.CommitAsync();
            return comment;
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Comment>> GetCommentWithBlogList(int id)
        {
            return await _repository.GetCommentWithBlogList(id);
        }

        public async Task RemoveAsync(Comment comment)
        {
            _repository.Remove(comment);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            _repository.Update(comment);
            await _unitOfWork.CommitAsync();
        }
    }
}
