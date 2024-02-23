﻿using CoreLayer.Models;
using CoreLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<Message> _DbSet;

        public MessageRepository(AppDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Message>();
        }

        public async Task AddAsync(Message message)
        {
           await _DbSet.AddAsync(message);
        }
    }
}