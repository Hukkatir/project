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
    public class MediumService : IMediumService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MediumService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Medium>> GetAll()
        {
            return await _repositoryWrapper.Medium.FindAll();
        }

        public async Task<Medium> GetById(int id)
        {
            var media = await _repositoryWrapper.Medium
                .FindByCondition(x => x.MediaId == id);
            return media.First();
        }

        public async Task Create(Medium model)
        {
            await _repositoryWrapper.Medium.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Medium model)
        {
            _repositoryWrapper.Medium.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var media = await _repositoryWrapper.Medium
                .FindByCondition(x => x.MediaId == id);

            _repositoryWrapper.Medium.Delete(media.First());
            _repositoryWrapper.Save();
        }
    }
}
