using CoreLayer.Models;
using CoreLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
