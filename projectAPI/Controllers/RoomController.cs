using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectAPI.Contracts.Room;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        /// <summary>
        /// Получение информации о всех комнатах 
        /// </summary>
        /// 
        // GET api/<RoomController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _roomService.GetAll();
            return Ok(Dto.Adapt<List<GetRoomResponse>>());
        }

        /// <summary>
        /// Получение информации о комнатах по id
        /// </summary>
        /// <param name="id">Идентификатор комнаты</param>

        // GET api/<RoomController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _roomService.GetById(id);
            return Ok(Dto.Adapt<GetRoomResponse>());
        }

        /// <summary>
        /// Создание новой комнаты
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Todo
        ///     {
        ///         "roomName": "Крутая комната для просмотра аниме :)",
        ///         "mediaId": 3,
        ///         "creatorId": 1
        ///     }
        ///     
        /// </remarks>
        /// <param name="room">Комната</param>
        /// <returns></returns>

        // POST api/<RoomController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateRoomRequest room)
        {
            var roomDto = room.Adapt<Room>();
            await _roomService.Create(roomDto);
            return Ok();
        }


        /// <summary>
        /// Изменение информации о комнате 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///         "roomId": 5,
        ///         "roomName": "Не очень крутая комната для просмотра аниме :(",
        ///         "mediaId": 3,
        ///         "creatorId": 1
        ///         "createdDateTime": "2024-10-21T12:46:44.000Z"
        ///     }
        ///     
        /// </remarks>
        /// <param name="room">Комната</param>
        /// <returns></returns>

        // PUT api/<RoomController>
        [HttpPut]
        public async Task<IActionResult> Update(GetRoomResponse room)
        {
            var Dto = room.Adapt<Room>();
            await _roomService.Update(Dto);
            return Ok();
        }


        /// <summary>
        /// Удаление комнаты
        /// </summary>
        /// <param name="id">Индентификатор комнаты</param>
        /// <returns></returns>

        // DELETE api/<RoomController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomService.Delete(id);
            return Ok();
        }
    }
}

