using CookBook.Options;
using CookBook.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Installers
{
    public class CacheInstaller : IInstaller
    {

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheOptions = new RedisCacheOptions();
            configuration.GetSection(nameof(redisCacheOptions)).Bind(redisCacheOptions);

            services.AddSingleton(redisCacheOptions);

            if (!redisCacheOptions.IsActive)
            {
                return;
            }

            services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheOptions.ConnectionString);

            services.AddSingleton<ICacheService, CacheService>();
        }

    }
}
