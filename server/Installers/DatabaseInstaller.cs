using CookBook.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CookBook.ExternalApi;

namespace CookBook.Installers
{
    public class DataBaseInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<DatabaseContext>();
                
            services.AddSingleton<IRecipeRepository, RecipeRepository>();
        }
    }
}