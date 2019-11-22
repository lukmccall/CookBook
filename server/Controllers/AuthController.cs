using System.Threading.Tasks;
using CookBook.API.Requests;
using CookBook.Services;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var authResponse = await _authService.RegisterAsync(request.Email, request.Password);
            if (authResponse.Success)
            {
                return Ok(authResponse);
            }

            return BadRequest(authResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var authResponse = await _authService.LoginAsync(request.Email, request.Password);
            if (authResponse.Success)
            {
                return Ok(authResponse);
            }

            return BadRequest(authResponse);
        }

        [HttpPost("refresh")]
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