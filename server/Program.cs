using System.Threading.Tasks;
using CookBook.Domain;
using logger;
using logger.LogStrategies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CookBook
{
    public class Program
    {

        void TEST(LoggerFacade<DiagnosticLogger> logger)
        {
            logger.Error("dsadsadasdasd");
        }

        public static async Task Main(string[] args)
        {
            var logger = new LoggerFacade<DiagnosticLogger>(new LoggerSettings
            {
                LogLevel = LogLevel.Info | LogLevel.Debug | LogLevel.Warn | LogLevel.Error | LogLevel.Fatal,
                DefaultLogStrategy = new ConsoleLogStrategy()
            });
            
            new Program().TEST(logger);
            
            var host = CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                if (await userManager.FindByEmailAsync("admin@admin.com") == null)
                {
                    await userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "admin",
                        Email = "admin@admin.com",
                        Age = 99,
                        Description = "Admin account",
                        EmailConfirmed = true
                    }, "root");
                }
            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

    }
}
