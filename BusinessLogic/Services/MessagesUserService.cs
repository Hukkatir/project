using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MessagesUserService : IMessagesUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MessagesUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<MessagesUser>> GetAll()
        {
            return await _repositoryWrapper.MessagesUser.FindAll();
        }

        public async Task<MessagesUser> GetById(int id)
        {
            var messagesUser = await _repositoryWrapper.MessagesUser
                .FindByCondition(x => x.MessageId == id);
            return messagesUser.First();
        }

        public async Task Create(MessagesUser model)
        {
            await _repositoryWrapper.MessagesUser.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(MessagesUser model)
        {
            _repositoryWrapper.MessagesUser.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var messagesUser = await _repositoryWrapper.MessagesUser
                .FindByCondition(x => x.MessageId == id);

            _repositoryWrapper.MessagesUser.Delete(messagesUser.First());
            _repositoryWrapper.Save();
        }
    }
}
