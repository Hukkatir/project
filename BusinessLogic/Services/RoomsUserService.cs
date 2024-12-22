using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domian.Interfaces;

namespace BusinessLogic.Services
{
    public class RoomsUserService : IRoomsUserService
    {

        private IRepositoryWrapper _repositoryWrapper;

        public RoomsUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<RoomsUser>> GetAll()
        {
            return await _repositoryWrapper.RoomsUser.FindAll();
        }

        public async Task<RoomsUser> GetById(int idRoom, int idUser)
        {
            var roomsUser = await _repositoryWrapper.RoomsUser
                .FindByCondition(x => x.RoomId == idRoom && x.UserId == idUser);
            return roomsUser.First();
        }

        public async Task Create(RoomsUser model)
        {
            await _repositoryWrapper.RoomsUser.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(RoomsUser model)
        {
            _repositoryWrapper.RoomsUser.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int idRoom, int idUser)
        {
            var roomsUser = await _repositoryWrapper.RoomsUser
                .FindByCondition(x => x.RoomId == idRoom && x.UserId == idUser);

            _repositoryWrapper.RoomsUser.Delete(roomsUser.First());
            _repositoryWrapper.Save();
        }
    }
}
