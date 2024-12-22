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
    public class GroupMediumService : IGroupMediumService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GroupMediumService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<GroupMedium>> GetAll()
        {
            return await _repositoryWrapper.GroupMedium.FindAll();
        }

        public async Task<GroupMedium> GetById(int id)
        {
            var groupMedium = await _repositoryWrapper.GroupMedium
                .FindByCondition(x => x.GroupId == id);
            return groupMedium.First();
        }

        public async Task Create(GroupMedium model)
        {
            await _repositoryWrapper.GroupMedium.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(GroupMedium model)
        {
            _repositoryWrapper.GroupMedium.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var groupMedium = await _repositoryWrapper.GroupMedium
                .FindByCondition(x => x.GroupId == id);

            _repositoryWrapper.GroupMedium.Delete(groupMedium.First());
            _repositoryWrapper.Save();
        }
    }
}
