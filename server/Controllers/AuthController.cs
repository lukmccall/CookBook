using System.Threading.Tasks;
using AutoMapper;
using CookBook.API;
using CookBook.API.Requests.AuthController;
using CookBook.API.Responses;
using CookBook.API.Responses.AuthController;
using CookBook.Domain.AuthController;
using CookBook.Services;
using logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(AuthSuccessResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(AuthFailedResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationFailedResponse), StatusCodes.Status422UnprocessableEntity)]
    public class AuthController : Controller
    {

        private readonly IAuthService _authService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public AuthController(IAuthService authService, IMapper mapper, ILogger logger)
        {
            _authService = authService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost(Urls.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var registerData = _mapper.Map<RegisterData>(request);
            var authResponse = await _authService.RegisterAsync(registerData);
            if (authResponse.Success)
            {
                return Ok(_mapper.Map<AuthSuccessResponse>(authResponse));
            }

            _logger.Error($"Register failed - {request.Email}");
            return BadRequest(_mapper.Map<AuthFailedResponse>(authResponse));
        }

        [HttpPost(Urls.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var loginData = _mapper.Map<LoginData>(request);
            var authResponse = await _authService.LoginAsync(loginData);
            if (authResponse.Success)
            {
                return Ok(_mapper.Map<AuthSuccessResponse>(authResponse));
            }

            _logger.Error($"Login failed - {request.Email}");
            return BadRequest(_mapper.Map<AuthFailedResponse>(authResponse));
        }

        [HttpPost(Urls.Auth.Logout)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            var logoutData = _mapper.Map<LogoutData>(request);
            var authResponse = await _authService.LogoutAsync(logoutData);
            if (authResponse.Success)
            {
                return NoContent();
            }

            return BadRequest(_mapper.Map<AuthFailedResponse>(authResponse));
        }

        [HttpPost(Urls.Auth.Refresh)]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
        {
            var refreshData = _mapper.Map<RefreshData>(request);
            var authResponse = await _authService.RefreshTokenAsync(refreshData);
            if (authResponse.Success)
            {
                return Ok(_mapper.Map<AuthSuccessResponse>(authResponse));
            }

            return BadRequest(_mapper.Map<AuthFailedResponse>(authResponse));
        }

    }
}
