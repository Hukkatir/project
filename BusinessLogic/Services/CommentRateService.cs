using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class CommentRateService : ICommentRateService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CommentRateService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<CommentRate>> GetAll()
        {
            return await _repositoryWrapper.CommentRate.FindAll();
        }

        public async Task<CommentRate> GetById(int id)
        {
            var commentRate = await _repositoryWrapper.CommentRate
                .FindByCondition(x => x.CommentRateId == id);
            return commentRate.First();
        }

        public async Task Create(CommentRate model)
        {
            await _repositoryWrapper.CommentRate.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(CommentRate model)
        {
            _repositoryWrapper.CommentRate.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var commentRate = await _repositoryWrapper.CommentRate
                .FindByCondition(x => x.CommentRateId == id);

            _repositoryWrapper.CommentRate.Delete(commentRate.First());
            _repositoryWrapper.Save();
        }
    }
}
