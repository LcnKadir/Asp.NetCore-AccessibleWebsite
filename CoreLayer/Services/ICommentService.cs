using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
    public interface ICommentService
    {
        Task RemoveAsync(Comment comment);
        Task UpdateAsync(Comment comment);
        Task<Comment> GetByIdAsync(int id);
        Task<Comment> AddAsync(Comment comment);
        Task<List<Comment>> GetCommentWithBlogList(int id);
    }
}
