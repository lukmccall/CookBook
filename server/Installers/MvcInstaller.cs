using CookBook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Installers
{
    public class MvcInstaller : IInstaller
    {

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("cors",
                    builder => { builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICommentsService, CommentsService>();
        }

    }
}
