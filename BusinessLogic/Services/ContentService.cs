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
    public class ContentService : IContentService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ContentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Content>> GetAll()
        {
            return await _repositoryWrapper.Content.FindAll();
        }

        public async Task<Content> GetById(int id)
        {
            var commentRate = await _repositoryWrapper.Content
                .FindByCondition(x => x.ContentId == id);
            return commentRate.First();
        }

        public async Task Create(Content model)
        {
            await _repositoryWrapper.Content.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Content model)
        {
            _repositoryWrapper.Content.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var content = await _repositoryWrapper.Content
                .FindByCondition(x => x.ContentId == id);

            _repositoryWrapper.Content.Delete(content.First());
            _repositoryWrapper.Save();
        }
    }
}
