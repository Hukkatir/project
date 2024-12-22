using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectAPI.Contracts.GroupMedium;
using projectAPI.Contracts.MediaFile;
using projectAPI.Contracts.Medium;
using projectAPI.Contracts.User;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediumController : ControllerBase
    {
        private IMediumService _mediumService;
        public MediumController(IMediumService mediumService)
        {
            _mediumService = mediumService;
        }

        /// <summary>
        /// Получение информации о всех медиа 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _mediumService.GetAll();
            return Ok(Dto.Adapt<List<GetMediumResponse>>());
        }

        /// <summary>
        /// Получение информации о мадиа по id 
        /// </summary>
        /// <param name="id">Идентификатор медиа</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _mediumService.GetById(id);
            return Ok(Dto.Adapt<GetMediumResponse>());
        }

        /// <summary>
        /// Создание нового медиа 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///         "mediaId": 10,
        ///         "title": "Коралина в Стране Кошмаров",
        ///         "releaseDate": "2009-02-05",
        ///         "plot": "Маленькая Коралина попадает в другой мир, скрытый за секретной дверцей. Этот мир — ее альтернативная жизнь, которая не перестает ее радовать, все здесь хорошо, но только до поры до времени. Однажды она понимает, что ее настоящим родителям за ее проделки угрожает смертельная опасность.",
        ///         "runtime": 100,
        ///         "imdbRating": 7,8,
        ///         "season": 0,
        ///         "episode": 0,
        ///         "mediaTypeId": 4,
        ///         "createdBy": 1,
        ///         "createdDateTime": "2024-10-22T09:28:57.804Z"
        ///     }
        /// 
        /// </remarks>
        /// <param name="medium">Медиа</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateMediaFileRequest medium)
        {

            var Dto = medium.Adapt<Medium>();
            await _mediumService.Create(Dto);
            return Ok();
        }


        /// <summary>
        /// Изменение информации о медиа 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///         "mediaId": 10,
        ///         "title": "Коралина в Стране Кошмаров",
        ///         "releaseDate": "2009-02-05",
        ///         "plot": "Маленькая Коралина попадает в другой мир, скрытый за секретной дверцей. Этот мир — ее альтернативная жизнь, которая не перестает ее радовать, все здесь хорошо, но только до поры до времени. Однажды она понимает, что ее настоящим родителям за ее проделки угрожает смертельная опасность.",
        ///         "runtime": 100,
        ///         "imdbRating": 9,
        ///         "season": 0,
        ///         "episode": 0,
        ///         "mediaTypeId": 4,
        ///         "createdBy": 1,
        ///         "createdDateTime": "2024-10-22T09:28:57.804Z"
        ///     }
        /// 
        /// </remarks>
        /// <param name="medium">Медиа</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(GetMediumResponse medium)
        {
            var Dto = medium.Adapt<Medium>();
            Dto.UpdatedDateTime = DateTime.UtcNow;
            await _mediumService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление медиа
        /// </summary>
        /// <param name="id">Идентификатор медиа</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediumService.Delete(id);
            return Ok();
        }
    }
}

