using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBook.API.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace CookBook.API.Validators
{
    public class ValidatorFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsFromValidator = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(pair => pair.Key, pair => pair.Value.Errors.Select(e => e.ErrorMessage))
                    .ToList();

                var response = new ValidationFailedResponse {Errors = new List<FiledErrors>()};
                foreach (var (field, messages) in errorsFromValidator)
                {
                    response.Errors.Add(new FiledErrors
                    {
                        Field = field,
                        Messages = messages
                    });
                }

                context.Result = new BadRequestObjectResult(response)
                {
                    StatusCode = StatusCodes.Status422UnprocessableEntity
                };

                return;
            }

            await next();
        }
    }
}