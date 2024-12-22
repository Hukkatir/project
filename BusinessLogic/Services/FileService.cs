using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Domain.Models.File;

namespace BusinessLogic.Services
{
    public class FileService : IFileService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<File>> GetAll()
        {
            return await _repositoryWrapper.Files.FindAll();
        }

        public async Task<File> GetById(int id)
        {
            var f = await _repositoryWrapper.Files
                .FindByCondition(x => x.FileId == id);
            return f.First();
        }

        public async Task Create(File model)
        {
            await _repositoryWrapper.Files.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(File model)
        {
            _repositoryWrapper.Files.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var f = await _repositoryWrapper.Files
                .FindByCondition(x => x.FileId == id);

            _repositoryWrapper.Files.Delete(f.First());
            _repositoryWrapper.Save();
        }
    }
}

