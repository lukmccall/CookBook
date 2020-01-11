using System.Threading.Tasks;
using CookBook.Domain;
using CookBook.Domain.AuthController;

namespace CookBook.Services
{
    public interface IAuthService
    {

        Task<AuthResult> RegisterAsync(RegisterData registerData);

        Task<AuthResult> LoginAsync(LoginData loginData);

        Task<AuthResult> LogoutAsync(LogoutData logoutData);

        Task<AuthResult> RefreshTokenAsync(RefreshData refreshData);

    }
}
