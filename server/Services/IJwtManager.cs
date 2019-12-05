using System.Security.Claims;
using System.Threading.Tasks;
using CookBook.Models;
using Microsoft.IdentityModel.Tokens;

namespace CookBook.Services
{
    public interface IJwtManager
    {
        string GetUserId(ClaimsPrincipal principal);

        ClaimsPrincipal GetPrincipalFromToken(string token);

        SecurityToken GenerateTokenForUser(ApplicationUser user);

        string SecurityTokenToString(SecurityToken securityToken);

        Task<JwtRefreshToken> GenerateRefreshTokenForJwtTokenAsync(ApplicationUser user, SecurityToken token);

        Task RevokeTokenAsync(ClaimsPrincipal principal);

        Task<JwtRefreshToken> GetRefreshToken(string refreshToken);

        Task UseRefreshToken(JwtRefreshToken refreshToken);

        Task<bool> CheckIfUserUsedVActiveTokenAsync(ClaimsPrincipal principal);

        bool ValidateRefreshToken(JwtRefreshToken refreshToken, ClaimsPrincipal claimsPrincipal);
    }
}