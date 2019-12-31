using System.Threading.Tasks;
using CookBook.API;
using CookBook.API.Requests;
using CookBook.API.Requests.AuthController;
using CookBook.API.Requests.UserController;
using CookBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [ApiController]
    [Authorize(Policy = "JWTToken")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet(Urls.User.GetCurrentUser)]
        public async Task<IActionResult> GeCurrentUser()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return Ok(user);
        }

        [HttpPatch(Urls.User.UpdateCurrentUser)]
        public async Task<IActionResult> UpdateCurrentUser([FromBody] UpdateCurrentUserRequest updatedUser)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }

            user.Age = updatedUser.Age ?? user.Age;
            user.UserSurname = updatedUser.UserSurname ?? user.UserSurname;
            user.Description = updatedUser.Description ?? user.Description;
            user.PhoneNumber = updatedUser.PhoneNumber ?? user.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }
        
        [HttpPatch(Urls.User.ChangeCurrentUserPassword)]
        public async Task<IActionResult> ChangeCurrentUserPassword([FromBody] ChangeCurrentUserPasswordRequest passwordRequest)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ChangePasswordAsync(user, passwordRequest.OldPassword, passwordRequest.NewPassword);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}