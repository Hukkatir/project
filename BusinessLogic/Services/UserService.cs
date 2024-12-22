using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Domian.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<User>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.UserId == id);
            return user.First();
        }

        public async Task Create(User model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Username))
            {
                throw new ArgumentException(nameof(model.Username));
            }
            if (string.IsNullOrEmpty(model.UserPassword))
            {
                throw new ArgumentException(nameof(model.UserPassword));
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentException(nameof(model.Email));
            }
            if (!IsValidEmail(model.Email))
            {
                throw new ArgumentException(nameof(model.Email));
            }
            if (string.IsNullOrEmpty(model.FirstName))
            {
                throw new ArgumentException(nameof(model.FirstName));
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                throw new ArgumentException(nameof(model.LastName));
            }

            await _repositoryWrapper.User.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(User model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Username))
            {
                throw new ArgumentException(nameof(model.Username));
            }
            if (string.IsNullOrEmpty(model.UserPassword))
            {
                throw new ArgumentException(nameof(model.UserPassword));
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentException(nameof(model.Email));
            }
            if (!IsValidEmail(model.Email))
            {
                throw new ArgumentException(nameof(model.Email));
            }
            if (string.IsNullOrEmpty(model.FirstName))
            {
                throw new ArgumentException(nameof(model.FirstName));
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                throw new ArgumentException(nameof(model.LastName));
            }


            if (model.DateOfBirth > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.DateOfBirth));
            }
            if (model.CreatedDateTime > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDateTime));
            }
            if (model.UpdatedDateTime.HasValue && model.UpdatedDateTime.Value > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.UpdatedDateTime));
            }
            if (model.DeletedDateTime.HasValue && model.DeletedDateTime.Value > DateTime.Now)
            {
                throw new ArgumentException("DeletedDateTime cannot be in the future.", nameof(model.DeletedDateTime));
            }


            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.UserId == id);

            _repositoryWrapper.User.Delete(user.First());
            _repositoryWrapper.Save();
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

}
