using System.Net.Http;
using CookBook.Services;
using logger;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Installers
{
    public class HttpClientInjectorInstaller : IInstaller
    {

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<HttpClientInjector, HttpClientInjector>();
            services.AddTransient(provider =>
            {
                var actionContextAccessor = provider.GetService<IActionContextAccessor>();
                if (actionContextAccessor.ActionContext.ActionDescriptor is ControllerActionDescriptor controllerAction)
                {
                    
                    var controllerName = controllerAction.ControllerName;
                    var clientInjector = provider.GetService<HttpClientInjector>();
                    return clientInjector.GetClientForState(controllerName);
                }
                provider.GetService<ILogger>().Fatal("Couldn't cast to controller action.");
                return new HttpClient(); // this shouldn't be executed
            });
        }

    }
}
