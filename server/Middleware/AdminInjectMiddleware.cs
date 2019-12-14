using System.Threading.Tasks;
using CookBook.Domain.AuthController;
using CookBook.Services;
using Microsoft.AspNetCore.Http;

namespace CookBook.Middleware
{
    public class AdminInjectMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminInjectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IAuthService authService)
        {
            var response = await authService.LoginAsync(new LoginData
            {
                Email = "admin@admin.com",
                Password = "root"
            });
            httpContext.Request.Headers["Authorization"] = "bearer " + response.Token;
            await _next(httpContext);
        }
    }
}