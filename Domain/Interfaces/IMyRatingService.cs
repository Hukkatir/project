using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMyRatingService
    {
        Task<List<MyRating>> GetAll();
        Task<MyRating> GetById(int id);
        Task Create(MyRating model);
        Task Update(MyRating model);
        Task Delete(int id);
    }
}
