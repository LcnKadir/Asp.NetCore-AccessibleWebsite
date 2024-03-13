using CoreLayer.Models;
using CoreLayer.Repositories;
using CoreLayer.Services;
using CoreLayer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class MessageService: IMessageService
    {
        private readonly IMessageRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IMessageRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Message> AddAsync(Message message)
        {
            await _repository.AddAsync(message);
            await _unitOfWork.CommitAsync();
            return message;
        }

        public async Task<List<Message>> GetwasPickClass(int id)
        {
            return await _repository.GetwasPickClass(id);
        }
    }
}
