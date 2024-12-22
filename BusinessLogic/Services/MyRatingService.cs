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
    public class MyRatingService : IMyRatingService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MyRatingService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<MyRating>> GetAll()
        {
            return await _repositoryWrapper.MyRating.FindAll();
        }

        public async Task<MyRating> GetById(int id)
        {
            var rating = await _repositoryWrapper.MyRating
                .FindByCondition(x => x.RatingId == id);
            return rating.First();
        }

        public async Task Create(MyRating model)
        {
            await _repositoryWrapper.MyRating.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(MyRating model)
        {
            _repositoryWrapper.MyRating.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var rating = await _repositoryWrapper.MyRating
                .FindByCondition(x => x.RatingId == id);

            _repositoryWrapper.MyRating.Delete(rating.First());
            _repositoryWrapper.Save();
        }
    }
}
