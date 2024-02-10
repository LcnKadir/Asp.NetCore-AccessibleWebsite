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
       private AppDbContext _appDbContext;
       
		public UnitOfWork(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public void Commit()
        {
			_appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
