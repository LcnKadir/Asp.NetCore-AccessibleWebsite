using CoreLayer.Models;
using CoreLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Comment> _DbSet;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Comment>();
        }

        public async Task AddAsync(Comment Comment)
        {
            await _DbSet.AddAsync(Comment);
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public async Task<List<Comment>> GetCommentWithBlogList(int id)
        {
            return await _context.Comments.Include(x => x.Blog).Where(x => x.AppUserId == id).ToListAsync();
        }

        public void Remove(Comment comment)
        {
            _DbSet.Remove(comment);
        }

        public void Update(Comment comment)
        {
            _DbSet.Update(comment);
        }


    }
}
