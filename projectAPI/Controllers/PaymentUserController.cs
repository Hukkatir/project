using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectAPI.Contracts.PaymentUser;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentUserController : ControllerBase
    {
        private IPaymentUserService _paymentUserService;
        public PaymentUserController(IPaymentUserService paymentUserService)
        {
            _paymentUserService = paymentUserService;
        }

        /// <summary>
        /// Получение информации о всех держателей карты 
        /// </summary>
        /// <returns></returns>

        // GET api/<PaymentUserController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _paymentUserService.GetAll();
            return Ok(Dto.Adapt<List<GetPaymentUserResponse>>());
        }

        /// <summary>
        /// Получение информации о картах пользователя по id 
        /// </summary>
        /// <param name="idPayment">Идентификатор карты</param>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns></returns>

        // GET api/<PaymentUserController>
        [HttpGet("{{idPayment}}/{{idUser}}")]
        public async Task<IActionResult> GetById(int idPayment, int idUser)
        {
            var Dto = await _paymentUserService.GetById(idPayment, idUser);
            return Ok(Dto.Adapt<GetPaymentUserResponse>());
        }

        /// <summary>
        /// Создание новых карт пользователю
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "idPayment": 4,
        ///       "idUser": 10,
        ///       "isActive": true
        ///     }
        ///
        /// </remarks>
        /// <param name="paymentUser">Карты пользователя</param>
        /// <returns></returns>

        // POST api/<PaymentUserController>
        [HttpPost]
        public async Task<IActionResult> Add(CreatePaymentUserRequest paymentUser)
        {
            var paymentUserDto = paymentUser.Adapt<PaymentUser>();
            await _paymentUserService.Create(paymentUserDto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о картах пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idPayment": 4,
        ///       "idUser": 10,
        ///       "isActive": false
        ///     }
        ///
        /// </remarks>
        /// <param name="paymentUser">Карты пользователя</param>
        /// <returns></returns>

        // PUT api/<PaymentUserController>
        [HttpPut]
        public async Task<IActionResult> Update(GetPaymentUserResponse paymentUser)
        {
            var Dto = paymentUser.Adapt<PaymentUser>();
            await _paymentUserService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление карты пользователя
        /// </summary>
        /// <param name="idPayment">Идентификатор карты</param>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns></returns>
        // DELETE api/<PaymentUserController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int idPayment, int idUser)
        {
            await _paymentUserService.Delete(idPayment, idUser);
            return Ok();
        }
    }
}
