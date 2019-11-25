using System.Threading.Tasks;
using CookBook.Domain;
using Microsoft.AspNetCore.Identity;

namespace CookBook.Services
{
    class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtManager _jwtManager;

        public AuthService(IJwtManager jwtManager, UserManager<IdentityUser> userManager)
        {
            _jwtManager = jwtManager;
            _userManager = userManager;
        }

        public async Task<AuthResult> RegisterAsync(string email, string password)
        {
            if (await _userManager.FindByEmailAsync(email) != null)
            {
                return AuthResult.CreateWithSingleError("This user already exists.");
            }

            var newUser = new IdentityUser
            {
                Email = email,
                UserName = email
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return AuthResult.CreateWithSingleError("Couldn't create a new user.");
            }

            return await GeneraAuthResultAsync(newUser);
        }

        public async Task<AuthResult> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                return AuthResult.CreateWithSingleError("Couldn't login.");
            }

            return await GeneraAuthResultAsync(user);
        }

        public async Task<AuthResult> LogoutAsync(string token)
        {
            var validatedToken = _jwtManager.GetPrincipalFromToken(token);

            if (validatedToken == null)
            {
                return AuthResult.CreateWithSingleError("Invalid token format.");
            }

            await _jwtManager.RevokeTokenAsync(validatedToken);

            return new AuthResult
            {
                Success = true
            };
        }

        public async Task<AuthResult> RefreshTokenAsync(string token, string refreshToken)
        {
            var claimsFromToken = _jwtManager.GetPrincipalFromToken(token);

            if (claimsFromToken == null)
            {
                return AuthResult.CreateWithSingleError("Invalid token format.");
            }

            var storedRefreshToken = await _jwtManager.GetRefreshToken(refreshToken);


            if (!_jwtManager.ValidateRefreshToken(storedRefreshToken, claimsFromToken))
            {
                return AuthResult.CreateWithSingleError("Invalid token");
            }

            await _jwtManager.UseRefreshToken(storedRefreshToken);

            var user = await _userManager.FindByIdAsync(_jwtManager.GetUserId(claimsFromToken));

            return await GeneraAuthResultAsync(user);
        }

        private async Task<AuthResult> GeneraAuthResultAsync(IdentityUser user)
        {
            var newToken = _jwtManager.GenerateTokenForUser(user);
            var newRefreshToken = await _jwtManager.GenerateRefreshTokenForJwtTokenAsync(user, newToken);

            if (newToken == null || newRefreshToken == null)
            {
                return AuthResult.CreateWithSingleError("Couldn't create token for the user.");
            }

            return new AuthResult
            {
                Success = true,
                Token = _jwtManager.SecurityTokenToString(newToken),
                RefreshToken = newRefreshToken.Token
            };
        }
    }
}