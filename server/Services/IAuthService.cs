using System.Threading.Tasks;
using CookBook.Domain;

namespace CookBook.Services
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(string email, string password);

        Task<AuthResult> LoginAsync(string email, string password);

        Task<AuthResult> RefreshTokenAsync(string token, string refreshToken);
    }
}