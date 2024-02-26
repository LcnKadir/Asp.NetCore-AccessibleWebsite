using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repositories
{
    public interface ICommentRepository
    {
        void Remove(Comment  comment);
        void Update(Comment comment);
        Task<Comment> GetByIdAsync(int id);
        Task AddAsync(Comment Comment);
        Task<List<Comment>> GetCommentWithBlogList(int id); //Kullanıcının kendi panelinde yorumlarını görmesini sağlanacak.
    }
}
