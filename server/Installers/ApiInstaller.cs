using CookBook.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Installers
{
    public class ApiInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var apiOptions = new ApiOptions();
            configuration.GetSection(nameof(ApiOptions)).Bind(apiOptions);

            services.AddSingleton(apiOptions);
        }
    }
}