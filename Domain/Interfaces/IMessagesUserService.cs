using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMessagesUserService
    {
        Task<List<MessagesUser>> GetAll();
        Task<MessagesUser> GetById(int id);
        Task Create(MessagesUser model);
        Task Update(MessagesUser model);
        Task Delete(int id);
    }
}
