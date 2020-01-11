using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CookBook.API;
using CookBook.API.Requests.RecipesController;
using CookBook.API.Responses.RecipesController;
using CookBook.ExternalApi;
using CookBook.ExternalApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class RecipesController : BaseExternalApiController
    {

        private readonly IRecipeRepository _recipeRepo;

        public RecipesController(IRecipeRepository recipeRepo, IMapper mapper) : base(mapper)
        {
            _recipeRepo = recipeRepo;
        }

        [HttpGet(Urls.Recipe.PriceBreakdown)]
        [ProducesResponseType(typeof(RecipesPriceBreakdownResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecipePriceBreakdown(long id)
        {
            return await WrapExternalRepositoryCall<RecipePriceBreakdown, RecipesPriceBreakdownResponse>(() =>
                _recipeRepo.GetRecipePriceBreakdown(id));
        }

        [HttpGet(Urls.Recipe.RecipeIngredients)]
        [ProducesResponseType(typeof(RecipeIngredientsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecipeIngredients(long id)
        {
            return await WrapExternalRepositoryCall<RecipeIngredients, RecipeIngredientsResponse>(() =>
                _recipeRepo.GetRecipeIngredientsById(id));
        }

        [HttpPost(Urls.Recipe.SearchByIngredients)]
        [ProducesResponseType(typeof(IEnumerable<RecipeResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchByIngredients([FromBody] IngredientsRequest list)
        {
            return await WrapExternalRepositoryCall<IList<Recipe>, IEnumerable<RecipeResponse>>(() =>
                _recipeRepo.FindRecipeByIngredients(Mapper.Map<IngredientsQuery>(list)));
        }

        [HttpGet(Urls.Recipe.RecipeInstructions)]
        [ProducesResponseType(typeof(IEnumerable<RecipeInstructionResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RecipeInstructions(long id, [FromQuery] bool? stepBreakdown = null)
        {
            return await WrapExternalRepositoryCall<IList<RecipeInstruction>, IEnumerable<RecipeInstructionResponse>>(
                () => _recipeRepo.GetAnalyzedRecipeInstructions(id, stepBreakdown));
        }

    }
}
