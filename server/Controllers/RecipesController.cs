using System.Threading.Tasks;
using CookBook.API;
using CookBook.API.Requests;
using CookBook.Services;
using CookBook.API.Requests.External;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers{
    [ApiController]
    public class RecipesController : Controller
    {
        private readonly IRecipeRepository _recipeRepo;

        public RecipesController(IRecipeRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        [HttpGet("/recipePriceBreakdown/{id}")]
        public IActionResult Get(long id){
            var model = _recipeRepo.GetRecipePriceBreakdown(id);

            if (model == null)
                return Forbid(); //or any other error code accordingly. Bad request is a strong candidate also.

            return Ok(model);
        }
    }
}
