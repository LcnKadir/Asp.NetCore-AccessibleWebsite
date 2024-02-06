using CoreLayer.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _Context;

        public UnitOfWork(DbContext context)
        {
            _Context = context;
        }

        public void Commit()
        {
            _Context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _Context.SaveChangesAsync();
        }
    }
}
