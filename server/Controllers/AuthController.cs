using System.Threading.Tasks;
using CookBook.API;
using CookBook.API.Requests;
using CookBook.Services;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost(Urls.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var authResponse = await _authService.RegisterAsync(request.Email, request.Password);
            if (authResponse.Success)
            {
                return Ok(authResponse);
            }

            return BadRequest(authResponse);
        }

        [HttpPost(Urls.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var authResponse = await _authService.LoginAsync(request.Email, request.Password);
            if (authResponse.Success)
            {
                return Ok(authResponse);
            }

            return BadRequest(authResponse);
        }

        [HttpPost(Urls.Auth.Logout)]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            var authResponse = await _authService.LogoutAsync(request.Token);
            if (authResponse.Success)
            {
                return NoContent();
            }

            return BadRequest(authResponse);
        }

        [HttpPost(Urls.Auth.Refresh)]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
        {
            var authResponse = await _authService.RefreshTokenAsync(request.Token, request.RefreshToken);
            if (authResponse.Success)
            {
                return Ok(authResponse);
            }

            return BadRequest(authResponse);
        }
    }
}