using CookBook.Data;
using CookBook.Models;
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

            services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.ClaimsIdentity.UserIdClaimType = "id";
                    options.Password.RequiredLength = 4;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<DatabaseContext>();
                
            services.AddSingleton<IRecipeRepository, RecipeRepository>();
            services.AddSingleton<IWidgetRepository, WidgetRepository>();

        }
    }
}