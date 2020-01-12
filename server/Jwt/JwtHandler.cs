using System.Threading.Tasks;
using CookBook.Services;
using logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace CookBook.Jwt
{
    public class JwtHandler : AuthorizationHandler<JwtRequirement>
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILogger _logger;

        private readonly IJwtManager _jwtManager;

        public JwtHandler(IJwtManager jwtManager, IHttpContextAccessor httpContextAccessor, ILogger logger)
        {
            _jwtManager = jwtManager;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            JwtRequirement requirement)
        {
            if (await _jwtManager.CheckIfUserUsedActiveTokenAsync(context.User))
            {
                _logger.Debug($"User tried to connect with inactive token. {context.User?.Identity?.Name}");

                context.Fail();
                _httpContextAccessor.HttpContext.Response.StatusCode = 401;
            }
            else
            {
                context.Succeed(requirement);
            }
        }

    }
}
