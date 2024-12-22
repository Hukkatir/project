using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectAPI.Contracts.Content;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private IContentService _contentService;
        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        /// <summary>
        /// Получение всего контента
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _contentService.GetAll();
            return Ok(Dto.Adapt<List<GetContentResponse>>());
        }
        /// <summary>
        /// Получение контента по id
        /// </summary>
        /// <param name="id">Идентификатор контента</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _contentService.GetById(id);
            return Ok(Dto.Adapt<GetContentResponse>());
        }

        /// <summary>
        /// Создание нового контента
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Todo
        ///     {
        ///         "authorId": 5, 
        ///         "mediaId": 10,
        ///         "categoryContentId": 3,
        ///         "title": "Провал Джокера 2",
        ///         "contentText": "В мировом прокате с оглушительным треском продолжает проваливаться «Джокер: Безумие на двоих». Продолжение хитового фильма 2019 года, который взял «Золотого льва» на Венецианском фестивале, а затем принес оскаровскую статуэтку Хоакину Фениксу, здорово разозлило фанатов и разочаровало критиков. Но все это часть плана Тодда Филлипса, который сам выступил в роли Джокера и провернул беспрецедентную акцию по уничтожению кинокомикса. Может, пора объяснить, почему «Безумие на двоих» вызывает восхищение несмотря ни на что?",
        ///         "createdBy": 1
        ///     }
        ///     
        /// </remarks>
        /// <param name="content">Rонтент</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateContentRequest content)
        {
            var Dto = content.Adapt<Content>();
            await _contentService.Create(Dto);
            return Ok();
        }
        /// <summary>
        /// Изменение информации о контенте 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Todo
        ///     {
        ///         "authorId": 5, 
        ///         "mediaId": 10,
        ///         "categoryContentId": 3,
        ///         "title": "Вы не поймете! Почему сиквел «Джокера» — главный поп-культурный феномен года",
        ///         "contentText": "В мировом прокате с оглушительным треском продолжает проваливаться «Джокер: Безумие на двоих». Продолжение хитового фильма 2019 года, который взял «Золотого льва» на Венецианском фестивале, а затем принес оскаровскую статуэтку Хоакину Фениксу, здорово разозлило фанатов и разочаровало критиков. Но все это часть плана Тодда Филлипса, который сам выступил в роли Джокера и провернул беспрецедентную акцию по уничтожению кинокомикса. Может, пора объяснить, почему «Безумие на двоих» вызывает восхищение несмотря ни на что?",
        ///         "createdBy": 1,
        ///         "createdDateTime": "2024-10-10T09:30:58.178Z",
        ///         "updatedBy": 2,
        ///         "updatedDateTime": "2024-11-01T09:32:18.238Z",
        ///         "deletedBy": 10,
        ///         "deletedDateTime": null
        ///     }
        ///   
        /// </remarks>
        /// <param name="content">Контент</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(GetContentResponse content)
        {
            var Dto = content.Adapt<Content>();
            Dto.UpdatedDateTime = DateTime.UtcNow;
            await _contentService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление контента по id
        /// </summary>
        /// <param name="id">Идентификатор контента</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _contentService.Delete(id);
            return Ok();
        }
    }
}
