using System.Threading.Tasks;
using CookBook.ExternalApi;
using Microsoft.AspNetCore.Mvc;
using CookBook.API;

namespace CookBook.Controllers
{
    [ApiController]
    public class RecipesController : Controller
    {
        private readonly IRecipeRepository _recipeRepo;

        public RecipesController(IRecipeRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        [HttpGet(Urls.Recipe.priceBreakdown)]
        public async Task<IActionResult> GetRecipePriceBreakdown(long id)
        {
            var model = await _recipeRepo.GetRecipePriceBreakdown(id);

            if (model == null)
                return Forbid(); //or any other error code accordingly. Bad request is a strong candidate also.

            return Ok(model);
        }
    }
}