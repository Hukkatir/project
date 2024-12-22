using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectAPI.Contracts.User;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Получение всех записей пользователей
        /// </summary>
        /// <returns></returns>
        // GET api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _userService.GetAll();
            return Ok(Dto.Adapt<List<GetUserResponse>>());
        }

        /// <summary>
        /// Получение записи пользователя по id
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        // GET api/<UserController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _userService.GetById(id);
            return Ok(Dto.Adapt<GetUserResponse>());
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        {
        ///             "roleId": 1,
        ///             "username": "hukkatir",
        ///             "roleId": 1,
        ///             "username": "hukkatir",
        ///             "userPassword": "Qwerty123!@#",
        ///             "email": "hukkatir@gmail.com",
        ///             "firstName": "Соня",
        ///             "lastName": "Дудина"
        ///         }  
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest user)
        {
            var Dto = user.Adapt<User>();
            await _userService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о пользователе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Todo
        ///     {
        ///         "userId": 10,
        ///         "roleId": 2,
        ///         "username": "Hukkatir",
        ///         "userPassword": "12345",
        ///         "email": "Hukkatir@gmail.com",
        ///         "firstName": "Иван",
        ///         "lastName": "Иванов",
        ///         "dateOfBirth": "2024-12-16T09:30:58.178Z",
        ///         "createdDateTime": "2024-10-10T09:30:58.178Z",
        ///         "updatedBy": 1,
        ///         "updatedDateTime": "2024-11-01T09:32:18.238Z",
        ///         "deletedBy": null,
        ///         "deletedDateTime": null
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>

        // PUT api/<UserController>
        [HttpPut]
        public async Task<IActionResult> Update(GetUserResponse user)
        {
            var Dto = user.Adapt<User>();
            Dto.UpdatedDateTime = DateTime.UtcNow;
            await _userService.Update(Dto);
            return Ok();
        }
        /// <summary>
        /// Удаление данных пользователя по id
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>

        // DELETE api/<UserController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}

