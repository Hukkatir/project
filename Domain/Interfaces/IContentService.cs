using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IContentService
    {
        Task<List<Content>> GetAll();
        Task<Content> GetById(int id);
        Task Create(Content model);
        Task Update(Content model);
        Task Delete(int id);
    }
}
