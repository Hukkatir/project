using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectAPI.Contracts.File;
using File = Domain.Models.File;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// Получение всех файлов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _fileService.GetAll();
            return Ok(Dto.Adapt<List<GetFileResponse>>());
        }


        /// <summary>
        /// Получение информации о файле по id
        /// </summary>
        /// <param name="id">Идентификатор файла</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _fileService.GetById(id);
            return Ok(Dto.Adapt<GetFileResponse>());
        }

        /// <summary>
        /// Создание нового файла 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///         "fileName": "9-1-1 s08e01",
        ///         "fileUrl": "https://hdrezka1twwpb.org/series/drama/26609-911-sluzhba-spaseniya-2018.html#t:35-s:8-e:1",
        ///         "categoryFileId": 1,
        ///         "createdBy": 5
        ///     }
        ///     
        /// </remarks>
        /// <param name="f">Файл</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateFileRequest f)
        {
            var Dto = f.Adapt<File>();
            await _fileService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о файле 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     PUT /Todo
        ///     {
        ///         "fileName": "9-1-1 s08e01",
        ///         "fileUrl": "https://hdrezka.org/series/drama/26609-911-sluzhba-spaseniya-2018.html#t:35-s:8-e:1",
        ///         "categoryFileId": 1,
        ///         "createdBy": 5,
        ///         "createdDateTime": "2024-10-23T10:21:54.302Z",
        ///         "updatedBy": 10,
        ///         "updatedDateTime": "2024-11-23T10:21:54.302Z"
        ///     }
        ///     
        /// </remarks>
        /// <param name="f">Файл</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(GetFileResponse f)
        {
            var Dto = f.Adapt<File>();
            Dto.UpdatedDateTime = DateTime.UtcNow;
            await _fileService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="id">Идентификатор файла</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _fileService.Delete(id);
            return Ok();
        }
    }
}


