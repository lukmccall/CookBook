using System.Threading.Tasks;
using CookBook.Domain;
using CookBook.Domain.AuthController;
using CookBook.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace CookBook.Services
{
    class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtManager _jwtManager;

        public AuthService(IJwtManager jwtManager, UserManager<ApplicationUser> userManager)
        {
            _jwtManager = jwtManager;
            _userManager = userManager;
        }

        public async Task<AuthResult> RegisterAsync(RegisterData registerData)
        {
            if (await _userManager.FindByEmailAsync(registerData.Email) != null)
            {
                return AuthResult.CreateWithSingleError("This user already exists.");
            }

            var newUser = new ApplicationUser
            {
                Email = registerData.Email,
                UserName = registerData.UserName
            };

            var createdUser = await _userManager.CreateAsync(newUser, registerData.Password);

            if (!createdUser.Succeeded)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            return await GeneraAuthResultAsync(newUser);
        }

        public async Task<AuthResult> LoginAsync(LoginData loginData)
        {
            var user = await _userManager.FindByEmailAsync(loginData.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginData.Password))
            {
                return AuthResult.CreateWithSingleError("Invalid `Email` or `Password`.");
            }

            return await GeneraAuthResultAsync(user);
        }

        public async Task<AuthResult> LogoutAsync(LogoutData logoutData)
        {
            var validatedToken = _jwtManager.GetPrincipalFromToken(logoutData.Token);

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

        public async Task<AuthResult> RefreshTokenAsync(RefreshData refreshData)
        {
            var claimsFromToken = _jwtManager.GetPrincipalFromToken(refreshData.Token);

            if (claimsFromToken == null)
            {
                return AuthResult.CreateWithSingleError("Invalid token format.");
            }

            var storedRefreshToken = await _jwtManager.GetRefreshToken(refreshData.Token);


            if (!_jwtManager.ValidateRefreshToken(storedRefreshToken, claimsFromToken))
            {
                return AuthResult.CreateWithSingleError("Invalid token");
            }

            await _jwtManager.UseRefreshToken(storedRefreshToken);

            var user = await _userManager.FindByIdAsync(_jwtManager.GetUserId(claimsFromToken));

            return await GeneraAuthResultAsync(user);
        }

        private async Task<AuthResult> GeneraAuthResultAsync(ApplicationUser user)
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