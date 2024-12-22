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
    public class MediaFileService : IMediaFileService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MediaFileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<MediaFile>> GetAll()
        {
            return await _repositoryWrapper.MediaFile.FindAll();
        }

        public async Task<MediaFile> GetById(int id)
        {
            var mediafile = await _repositoryWrapper.MediaFile
                .FindByCondition(x => x.MediaFileId == id);
            return mediafile.First();
        }

        public async Task Create(MediaFile model)
        {
            await _repositoryWrapper.MediaFile.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(MediaFile model)
        {
            _repositoryWrapper.MediaFile.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var mediafile = await _repositoryWrapper.MediaFile
                .FindByCondition(x => x.MediaFileId == id);

            _repositoryWrapper.MediaFile.Delete(mediafile.First());
            _repositoryWrapper.Save();
        }
    }
}

