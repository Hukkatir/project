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
    public class PaymentUserService : IPaymentUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PaymentUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PaymentUser>> GetAll()
        {
            return await _repositoryWrapper.PaymentUser.FindAll();
        }

        public async Task<PaymentUser> GetById(int idPayment, int idUser)
        {
            var paymentUser = await _repositoryWrapper.PaymentUser
                .FindByCondition(x => x.PaymentId == idPayment && x.UserId == idUser);
            return paymentUser.First();
        }

        public async Task Create(PaymentUser model)
        {
            await _repositoryWrapper.PaymentUser.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(PaymentUser model)
        {
            _repositoryWrapper.PaymentUser.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int idPayment, int idUser)
        {
            var paymentUser = await _repositoryWrapper.PaymentUser
                .FindByCondition(x => x.PaymentId == idPayment && x.UserId == idUser);

            _repositoryWrapper.PaymentUser.Delete(paymentUser.First());
            _repositoryWrapper.Save();
        }
    }
}
