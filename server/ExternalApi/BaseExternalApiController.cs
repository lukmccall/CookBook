using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.ExternalApi
{
    public abstract class BaseExternalApiController : Controller
    {

        protected readonly IMapper Mapper;

        protected BaseExternalApiController(IMapper mapper)
        {
            Mapper = mapper;
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
            catch (WebserviceException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
