using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectAPI.Contracts.CommentRate;
using Mapster;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentRateController : ControllerBase
    {
        private ICommentRateService _commentRateService;
        public CommentRateController(ICommentRateService commentRateService)
        {
            _commentRateService = commentRateService;
        }
        /// <summary>
        /// Полученне информации о всех оценках с комментариями
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _commentRateService.GetAll();
            return Ok(Dto.Adapt<List<GetCommentRateResponse>>());
        }

        /// <summary>
        /// Получение информации об оценке по id
        /// </summary>
        /// <param name="id">Идентификатор оценки</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _commentRateService.GetById(id);
            return Ok(Dto.Adapt<GetCommentRateResponse>());
        }

        /// <summary>
        /// Создание новой оценки с комментарием
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        ///     
        ///     POST /Todo
        ///     {
        ///         "commentId": 10,
        ///         "userId": 5,
        ///         "rating": 7
        ///        
        ///     }
        ///     
        /// </remarks>
        /// <param name="commentRate">Оценка</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateCommentRateRequest commentRate)
        {
            var Dto = commentRate.Adapt<CommentRate>();
            await _commentRateService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации оценки
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        ///     
        ///     POST /Todo
        ///     {
        ///         "commentId": 10,
        ///         "userId": 5,
        ///         "rating": 10
        ///     }
        ///     
        /// </remarks>
        /// <param name="commentRate">Оценка</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(GetCommentRateResponse commentRate)
        {
            var Dto = commentRate.Adapt<CommentRate>();
            Dto.UpdatedDateTime = DateTime.UtcNow;
            await _commentRateService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление оценки
        /// </summary>
        /// <param name="id">Идентификатор оценки</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentRateService.Delete(id);
            return Ok();
        }
    }
}
