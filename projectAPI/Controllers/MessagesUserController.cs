using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectAPI.Contracts.MessagesUser;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesUserController : ControllerBase
    {
        private IMessagesUserService _messagesUserService;
        public MessagesUserController(IMessagesUserService messagesUserService)
        {
            _messagesUserService = messagesUserService;
        }

        /// <summary>
        ///  Получение всех сообщений пользователей
        /// </summary>
        /// <returns></returns>

        // GET api/<MessageUserController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _messagesUserService.GetAll();
            return Ok(Dto.Adapt<List<GetMessagesUserResponse>>());
        }

        /// <summary>
        /// Получение информации о сообщении по id
        /// </summary>
        /// <param name="id">Идентификатор сообщения</param>
        /// <returns></returns>

        // GET api/<MessageUserController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _messagesUserService.GetById(id);
            return Ok(Dto.Adapt<GetMessagesUserResponse>());
        }

        /// <summary>
        /// Создание нового сообщения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "userId": 10,
        ///       "roomId": 6,
        ///       "statusMessageId": 1,
        ///       "messageText": "hello there!"
        ///     }
        ///
        /// </remarks>
        /// <param name="messagesUser">Сообщение</param>
        /// <returns></returns>

        // POST api/<MessageUserController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateMessagesUserRequest messagesUser)
        {
            var Dto = messagesUser.Adapt<MessagesUser>();
            await _messagesUserService.Create(Dto);
            return Ok();
        }


        /// <summary>
        /// Изменение информации о сообщении
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "messageId": 50,
        ///       "userId": 10,
        ///       "roomId": 6,
        ///       "statusMessageId": 1,
        ///       "sendingDate": "2024-10-22T09:16:19.373Z",
        ///       "messageText": "bye there!",
        ///       "updatedDateTime": "2024-12-16T09:30:58.178Z",
        ///     }
        ///
        /// </remarks>
        /// <param name="messagesUser">Пользователь</param>
        /// <returns></returns>

        // PUT api/<MessageUserController>
        [HttpPut]
        public async Task<IActionResult> Update(GetMessagesUserResponse messagesUser)
        {
            var Dto = messagesUser.Adapt<MessagesUser>();
            Dto.UpdatedDateTime = DateTime.UtcNow;
            await _messagesUserService.Update(Dto);

            return Ok();
        }
        /// <summary>
        /// Удаление сообщения 
        /// </summary>
        /// <param name="id">Идентификатор сообщения</param>
        /// <returns></returns>

        // DELETE api/<MessageUserController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _messagesUserService.Delete(id);
            return Ok();
        }
    }
}
