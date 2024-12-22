using Domian.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using BusinessLogic.Services;
using projectAPI.Contracts.Comment;
using Mapster;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Получение всех комментариев
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _commentService.GetAll();
            return Ok(Dto.Adapt<List<GetCommentResponse>>());
        }

        /// <summary>
        /// Получение информации о комментарии по id
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _commentService.GetById(id);
            return Ok(Dto.Adapt<GetCommentResponse>());
        }

        /// <summary>
        /// Создание нового комментария 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Todo
        ///     {
        ///         "userId": 10,
        ///         "commentText": "Супер важный комменитарий"
        ///     }
        ///     
        /// </remarks>
        /// <param name="comment">Комментарий</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateCommentRequest request)
        {
            var commentDto = request.Adapt<Comment>();
            await _commentService.Create(commentDto);
            return Ok(); ;
        }

        /// <summary>
        /// Изменение информации комментария 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Todo
        ///     {
        ///         "userId": 10,
        ///         "commentText": "Не осчень важный комментарий", 
        ///         "createdDateTime": "2024-10-23T11:03:05.104Z"
        ///         "updatedDateTime": "2024-10-23T13:13:05.104Z",
        ///         "deletedDateTime": null
        ///     }
        ///     
        /// </remarks>
        /// <param name="comment">Комментарий</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(GetCommentResponse response)
        {

            var Dto = response.Adapt<Comment>();
            Dto.UpdatedDateTime = DateTime.UtcNow;
            await _commentService.Update(Dto);

            return Ok();
        }

        /// <summary>
        /// Удаление комментария
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentService.Delete(id);
            return Ok();
        }
    }
}
