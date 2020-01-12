using System;
using System.Threading.Tasks;
using AutoMapper;
using logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.ExternalApi
{
    public abstract class BaseExternalApiController : Controller
    {

        protected readonly IMapper Mapper;

        private readonly ILogger _logger;

        protected BaseExternalApiController(IMapper mapper, ILogger logger)
        {
            Mapper = mapper;
            _logger = logger;
        }

        protected async Task<IActionResult> WrapExternalRepositoryCall<T, TMapType>(Func<Task<T>> call)
        {
            try
            {
                var result = await call.Invoke();
                return Ok(Mapper.Map<TMapType>(result));
            }
            catch (RepositoryException)
            {
                return NotFound();
            }
            catch (WebserviceException e)
            {
                _logger.Fatal($"Error occurred while connecting with external API. {e.Message}");
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
            catch (Exception e)
            {
                _logger.Fatal($"Error occurred while connecting with external API. {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
