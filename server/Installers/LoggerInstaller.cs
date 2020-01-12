using logger;
using logger.LogStrategies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Installers
{
    public class LoggerInstaller : IInstaller
    {

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var logger = new LoggerFacade<DiagnosticLogger>(new LoggerSettings
            {
                LogLevel = LogLevel.Debug | LogLevel.Error | LogLevel.Fatal | LogLevel.Info | LogLevel.Warn,
                DefaultLogStrategy = new ConsoleLogStrategy()
            });
            
            services.AddSingleton<ILogger>(logger);
        }

    }
}
