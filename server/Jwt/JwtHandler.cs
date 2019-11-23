using System.Security.Claims;
using System.Threading.Tasks;
using CookBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;

namespace CookBook.Jwt
{
    public class JwtHandler : AuthorizationHandler<JwtRequirement>
    {
        private readonly ICacheService _cache;

        public JwtHandler(ICacheService cache)
        {
            _cache = cache;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            JwtRequirement requirement)
        {
            var jit = context.User.FindFirstValue(JwtRegisteredClaimNames.Jti);
            if (await _cache.HasKeyAsync(jit))
            {
                context.Fail();
            }
            else
            {
                context.Succeed(requirement);
            }
        }
    }
}