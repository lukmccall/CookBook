using System.Threading.Tasks;
using CookBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace CookBook.Jwt
{
    public class JwtHandler : AuthorizationHandler<JwtRequirement>
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IJwtManager _jwtManager;

        public JwtHandler(IJwtManager jwtManager, IHttpContextAccessor httpContextAccessor)
        {
            _jwtManager = jwtManager;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            JwtRequirement requirement)
        {
            if (await _jwtManager.CheckIfUserUsedActiveTokenAsync(context.User))
            {
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
