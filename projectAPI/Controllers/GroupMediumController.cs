using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectAPI.Contracts.GroupMedium;
using projectAPI.Contracts.User;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMediumController : ControllerBase
    {
        private IGroupMediumService _groupMediumService;
        public GroupMediumController(IGroupMediumService groupMediumService)
        {
            _groupMediumService = groupMediumService;
        }

        /// <summary>
        /// Получение информации о всех группах 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _groupMediumService.GetAll();
            return Ok(Dto.Adapt<List<GetGroupMediumResponse>>());
        }

        /// <summary>
        /// Получение информации о группе по id
        /// </summary>
        /// <param name="id">Идентификатор группы</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _groupMediumService.GetById(id);
            return Ok(Dto.Adapt<GetGroupMediumResponse>());
        }

        /// <summary>
        /// Создание новой группы 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Todo
        ///     {
        ///         "groupName": "9-1-1 1 сезон",
        ///         "groupDescrip": "Сериал расскажет о работе полицейских, «Скорой помощи» и пожарной службы. Все они выполняют свой долг, часто рискуя жизнью и попадая в самые пугающие и шокирующие ситуации. Смысл их ежедневной работы состоит в охране безопасности улиц и помощи всем, кто в ней нуждается."
        ///     }
        /// 
        /// </remarks>
        /// <param name="GroupMedium">Группа</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateGroupMediumRequest groupMedium)
        {
            var Dto = groupMedium.Adapt<GroupMedium>();
            await _groupMediumService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о группе
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        ///     
        ///     PUT /Todo
        ///     {
        ///         "groupName": "9-1-1 1 сезон",
        ///         "groupDescrip": "Сериал расскажет о работе полицейских, «Скорой помощи» и пожарной службы. Все они выполняют свой долг, часто рискуя жизнью и попадая в самые пугающие и шокирующие ситуации. Смысл их ежедневной работы состоит в охране безопасности улиц и помощи всем, кто в ней нуждается."
        ///        
        ///     }
        ///     
        /// </remarks>
        /// <param name="GroupMedium">Группа</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(GetGroupMediumResponse groupMedium)
        {
            var Dto = groupMedium.Adapt<GroupMedium>();
            await _groupMediumService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление группы
        /// </summary>
        /// <param name="id">Идентификатор группы</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupMediumService.Delete(id);
            return Ok();
        }
    }
}

