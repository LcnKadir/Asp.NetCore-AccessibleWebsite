using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services
{
    public interface IAccessibleUserService
    {
        Task<AccessibleUser> AddAsync(AccessibleUser accessibleUser);
        Task RemoveAsync(AccessibleUser accessibleUser);
        Task UpdateAsync(AccessibleUser accessibleUser);
        Task<AccessibleUser> GetByIdAsync(int id);
        Task<IEnumerable<AccessibleUser>> GetAllAsync();

    }
}
