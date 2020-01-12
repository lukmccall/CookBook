using System;
using System.Collections.Generic;
using System.Linq;
using logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CookBook.Swagger
{
    public class AssignJwtSecurityRequirements : IOperationFilter
    {

        private readonly ILogger _logger;

        public AssignJwtSecurityRequirements(ILogger logger)
        {
            _logger = logger;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Determine if the operation has the Authorize filer
            var filterDescriptors = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var hasAuthFilter = filterDescriptors
                .Select(filterInfo => filterInfo.Filter)
                .Any(filter => filter is AuthorizeFilter);
            var allowAnonymous = filterDescriptors
                .Select(filterInfo => filterInfo.Filter)
                .Any(filter => filter is IAllowAnonymousFilter);
            var hasAuthMetadata = false;
            try
            {
                hasAuthMetadata = context.ApiDescription.ActionDescriptor.EndpointMetadata
                    .Where(x => x is AuthorizeAttribute)
                    // ReSharper disable once SuspiciousTypeConversion.Global
                    .Cast<AuthorizeAttribute>().Any(x => x.Policy == "JWTToken");
            }
            catch (InvalidCastException)
            {
                _logger.Fatal($"Couldn't cast to `AuthorizeAttribute`.");
            }

            if (!hasAuthFilter && !hasAuthMetadata || allowAnonymous)
            {
                return;
            }

            // Initialize the operation.security property
            if (operation.Security == null)
            {
                operation.Security = new List<OpenApiSecurityRequirement>();
            }

            // Add the appropriate security definition to the operation
            var jwtRequirement = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            };
            operation.Security.Add(jwtRequirement);
        }

    }
}
