using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CookBook.API;
using CookBook.API.Requests.CommentsController;
using CookBook.API.Responses;
using CookBook.API.Responses.CommentsController;
using CookBook.Domain;
using CookBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [ApiController]
    public class CommentsController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ICommentsService _commentsService;

        private readonly IMapper _mapper;

        public CommentsController(ICommentsService commentsService, IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _commentsService = commentsService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet(Urls.Comments.GetComments)]
        [ProducesResponseType(typeof(IEnumerable<CommentsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetComments([FromRoute] long id)
        {
            var comments = await _commentsService.GetAllCommentsAsync(id);
            return Ok(_mapper.Map<IEnumerable<CommentsResponse>>(comments));
        }

        [HttpPost(Urls.Comments.AddComment)]
        [Authorize(Policy = "JWTToken")]
        [ProducesResponseType(typeof(IEnumerable<CommentsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationFailedResponse), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> AddComment([FromRoute] long id, [FromBody] CommentRequest request)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _commentsService.AddCommentAsync(id, user, request.Body);
            if (result)
            {
                return NoContent();
            }

            return BadRequest();
        }

    }
}
