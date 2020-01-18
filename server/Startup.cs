using System.IO;
using CookBook.API.Validators;
using CookBook.Extensions;
using CookBook.Middleware;
using CookBook.Options;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace CookBook
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => { options.Filters.Add<ValidatorFilter>(); })
                .AddFluentValidation(
                    configuration =>
                    {
                        configuration.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                        configuration.RegisterValidatorsFromAssemblyContaining<Startup>();
                    });
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.InstallServicesFromAssembly(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("cors");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMiddleware<AdminInjectMiddleware>(); // always logged 
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            var cachePeriod = env.IsDevelopment() ? "600" : "604800";
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Static")),
                RequestPath = "/static",
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                }
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Static")),
                RequestPath = new PathString("/static")
            });


            var swaggerOptions = new SwaggerOptions();

            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

    }
}
