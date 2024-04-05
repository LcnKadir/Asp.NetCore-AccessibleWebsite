using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Repositories
{
    public interface IMessageRepository
    {
        Task AddAsync(Message message);
        Task<List<Message>> GetwasPickClass(int id); //Kullanıcı haftalık katıldığı dersleri görebilecek.

        Task<IEnumerable<Message>> GetAllMessageAsync();
    }
}
