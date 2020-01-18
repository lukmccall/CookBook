using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using CookBook.API;
using CookBook.API.Requests.AuthController;
using CookBook.API.Requests.UserController;
using CookBook.API.Responses;
using CookBook.API.Responses.UserController;
using CookBook.Domain;
using logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [ApiController]
    [Authorize(Policy = "JWTToken")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class UserController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public UserController(UserManager<ApplicationUser> userManager, IMapper mapper, ILogger logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(Urls.User.GetCurrentUser)]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GeCurrentUser()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return Ok(_mapper.Map<UserResponse>(user));
        }

        [HttpPatch(Urls.User.UpdateCurrentUser)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCurrentUser([FromBody] UpdateCurrentUserRequest updatedUser)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = updatedUser.UserName ?? user.UserSurname;
            user.Age = updatedUser.Age ?? user.Age;
            user.UserSurname = updatedUser.UserSurname ?? user.UserSurname;
            user.Description = updatedUser.Description ?? user.Description;
            user.PhoneNumber = updatedUser.PhoneNumber ?? user.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                _logger.Info($"User updated successfully - {user.Email}.");
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPatch(Urls.User.ChangeCurrentUserPassword)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeCurrentUserPassword(
            [FromBody] ChangeCurrentUserPasswordRequest passwordRequest)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }

            var result =
                await _userManager.ChangePasswordAsync(user, passwordRequest.OldPassword, passwordRequest.NewPassword);

            if (result.Succeeded)
            {
                _logger.Info($"Password updated successfully - {user.Email}.");
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPost(Urls.User.ChangePicture)]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(ValidationFailedResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePicture(IFormFile picture)
        {
            var pathToStaticFolder = Path.Combine(Directory.GetCurrentDirectory(), "Static");
            var extension = Path.GetExtension(picture.FileName);
            var newName =
                $"{GeCurrentUser().Id}_{DateTime.Now:yyyy-M-d_HH:mm}{Guid.NewGuid().ToString().Substring(0, 8)}{extension}";

            await using var file = System.IO.File.Open(Path.Combine(pathToStaticFolder, newName), FileMode.CreateNew);
            await picture.CopyToAsync(file);

            var url = $"/static/{newName}";

            return Ok(url);
        }

    }
}
