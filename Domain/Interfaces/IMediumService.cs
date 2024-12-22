using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMediumService
    {
        Task<List<Medium>> GetAll();
        Task<Medium> GetById(int id);
        Task Create(Medium model);
        Task Update(Medium model);
        Task Delete(int id);


    }
}
