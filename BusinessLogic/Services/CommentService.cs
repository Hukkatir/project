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
    public class CommentService : ICommentService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CommentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _repositoryWrapper.Comment.FindAll();
        }

        public async Task<Comment> GetById(int id)
        {
            var comment = await _repositoryWrapper.Comment
                .FindByCondition(x => x.CommentId == id);
            return comment.First();
        }

        public async Task Create(Comment model)
        {
            await _repositoryWrapper.Comment.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Comment model)
        {
            _repositoryWrapper.Comment.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var comment = await _repositoryWrapper.Comment
                .FindByCondition(x => x.CommentId == id);

            _repositoryWrapper.Comment.Delete(comment.First());
            _repositoryWrapper.Save();
        }
    }
}
