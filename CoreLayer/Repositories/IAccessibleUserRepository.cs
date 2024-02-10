using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repositories
{
    public interface IAccessibleUserRepository
    {
        Task AddAsync(AccessibleUser accessibleUser);
        void Update(AccessibleUser accessibleUser);
        void Remove(AccessibleUser accessibleUser);
        void RemoveRange(IQueryable<AccessibleUser> entities);
        Task<AccessibleUser> GetByIdAsync(int id);
        Task<IEnumerable<AccessibleUser>> GetAllAsync();

    }
}
