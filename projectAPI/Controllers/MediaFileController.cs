using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectAPI.Contracts.MediaFile;
using projectAPI.Contracts.User;

namespace projectAPI.Controllers
{
    /// <summary>
    /// Контроллер для управления медиафайлами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MediaFileController : ControllerBase
    {
        private IMediaFileService _mediaFileService;
        public MediaFileController(IMediaFileService mediaFileService)
        {
            _mediaFileService = mediaFileService;
        }

        /// <summary>
        /// Получение информации о всех медиафайлах
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _mediaFileService.GetAll();
            return Ok(Dto.Adapt<List<GetMediaFileResponse>>());
        }

        /// <summary>
        /// Получение медиафайла по id 
        /// </summary>
        /// <param name="id">Идентификатор медиафайла</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _mediaFileService.GetById(id);
            return Ok(Dto.Adapt<GetMediaFileResponse>());
        }

        /// <summary>
        /// Добавление нового медиафайла
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///         "mediaId": 1,
        ///         "fileId": 5,
        ///         "mediaFileName": "9-1-1_s08e01"
        ///     }
        /// 
        /// </remarks>
        /// <param name="mediafile">Медиафайл</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateMediaFileRequest mediafile)
        {
            var Dto = mediafile.Adapt<MediaFile>();
            await _mediaFileService.Create(Dto);
            return Ok();
        }


        /// <summary>
        /// Изменение информации о медиофайле
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     PUT /Todo
        ///     {
        ///         "mediaFileId": 5,
        ///         "mediaId": 1,
        ///         "fileId": 5,
        ///         "mediaFileName": "9-1-1_s08e02"
        ///     }
        /// 
        /// </remarks>
        /// <param name="mediafile">Медиафайл</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(GetMediaFileResponse mediafile)
        {
            var Dto = mediafile.Adapt<MediaFile>();
            await _mediaFileService.Update(Dto);
            return Ok();

        }

        /// <summary>
        /// Удаление медиафайла
        /// </summary>
        /// <param name="id">Идентификатор медиафайла</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediaFileService.Delete(id);
            return Ok();
        }
    }
}

