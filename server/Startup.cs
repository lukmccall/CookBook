using CookBook.Extensions;
using CookBook.Middleware;
using CookBook.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using CookBook.API.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

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

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("cors");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMiddleware<AdminInjectMiddleware>();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

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