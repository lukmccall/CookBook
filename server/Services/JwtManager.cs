using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CookBook.Data;
using CookBook.Domain;
using CookBook.Extensions;
using CookBook.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CookBook.Services
{
    public class JwtManager : IJwtManager
    {

        private const string UserIdKey = "id";

        private readonly ICacheService _cache;

        private readonly DatabaseContext _context;

        private readonly JwtOptions _jwtSettings;

        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtManager(TokenValidationParameters tokenValidationParameters, JwtOptions jwtSettings,
            DatabaseContext context, ICacheService cache)
        {
            _tokenValidationParameters = tokenValidationParameters;
            _jwtSettings = jwtSettings;
            _context = context;
            _cache = cache;
        }

        public string GetUserId(ClaimsPrincipal principal)
        {
            return principal.Claims.Single(x => x.Type == UserIdKey).Value;
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenValidationParameters = _tokenValidationParameters.Clone();
                tokenValidationParameters.ValidateLifetime = false;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                return !IsJwtWithValidSecurityAlgorithm(validatedToken) ? null : principal;
            }
            catch
            {
                return null;
            }
        }

        public SecurityToken GenerateTokenForUser(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(UserIdKey, user.Id)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.CreateToken(tokenDescriptor);
        }

        public string SecurityTokenToString(SecurityToken securityToken)
        {
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public async Task<JwtRefreshToken> GenerateRefreshTokenForJwtTokenAsync(ApplicationUser user,
            SecurityToken token)
        {
            var refreshToken = new JwtRefreshToken
            {
                JwtId = token.Id,
                UserId = user.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6)
            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return refreshToken;
        }

        public async Task RevokeTokenAsync(ClaimsPrincipal principal)
        {
            var jti = principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            await _cache.PutStringAsync(jti, DateTime.UtcNow.Add(_jwtSettings.TokenLifetime).GetTimeSpan(), "0");
        }

        public async Task<JwtRefreshToken> GetRefreshToken(string refreshToken)
        {
            return await _context.RefreshTokens.SingleOrDefaultAsync(x => x.Token == refreshToken);
        }

        public async Task UseRefreshToken(JwtRefreshToken refreshToken)
        {
            refreshToken.Used = true;
            _context.RefreshTokens.Update(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckIfUserUsedActiveTokenAsync(ClaimsPrincipal principal)
        {
            var jti = principal.FindFirstValue(JwtRegisteredClaimNames.Jti);
            return jti != null && await _cache.HasKeyAsync(jti);
        }

        public bool ValidateRefreshToken(JwtRefreshToken refreshToken, ClaimsPrincipal claimsPrincipal)
        {
            var jti = claimsPrincipal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            return refreshToken != null &&
                   DateTime.UtcNow <= refreshToken.ExpiryDate &&
                   !refreshToken.Invalidated &&
                   !refreshToken.Used &&
                   refreshToken.JwtId == jti;
        }

        private static bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return validatedToken is JwtSecurityToken jwtSecurityToken &&
                   jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                       StringComparison.InvariantCultureIgnoreCase);
        }

    }
}
