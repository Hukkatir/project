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
    public class RoomService : IRoomService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RoomService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Room>> GetAll()
        {
            return await _repositoryWrapper.Room.FindAll();
        }

        public async Task<Room> GetById(int id)
        {
            var room = await _repositoryWrapper.Room
                .FindByCondition(x => x.RoomId == id);
            return room.First();
        }

        public async Task Create(Room model)
        {
            await _repositoryWrapper.Room.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Room model)
        {
            _repositoryWrapper.Room.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var room = await _repositoryWrapper.Room
                .FindByCondition(x => x.RoomId == id);

            _repositoryWrapper.Room.Delete(room.First());
            _repositoryWrapper.Save();
        }
    }
}
