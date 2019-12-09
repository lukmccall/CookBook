using System.Threading.Tasks;
using CookBook.ExternalApi;
using Microsoft.AspNetCore.Mvc;
using CookBook.API;
using CookBook.ExternalApi.Models;
using System;
using Microsoft.AspNetCore.Http;

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

        [HttpGet(Urls.Recipe.PriceBreakdown)]
        public async Task<IActionResult> GetRecipePriceBreakdown(long id)
        {
            try
            {
                var model = await _recipeRepo.GetRecipePriceBreakdown(id);
                return Ok(model);
            }
            catch (Exception e)
            {
                return new FailRequest(e.GetType(), e.Message);
            }
        }

        [HttpGet]
        [Route(Urls.Recipe.RecipeIngredients)]
        [ProducesResponseType(typeof(RecipeIngredients), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FailRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRecipeIngredients(long id)
        {
            try
            {
                var model = await _recipeRepo.GetRecipeIngredientsById(id);
                return Ok(model);
            }
            catch (Exception e)
            {
                return new FailRequest(e.GetType(), e.Message);
            }
        }

        [HttpPost]
        [Route(Urls.Recipe.SearchByIngredients)]
        public async Task<IActionResult> SearchByIngredients([FromBody] IngredientsQuery list)
        {
            try
            {
                var model = await _recipeRepo.FindRecipeByIngredients(list);
                return Ok(model);
            }
            catch (Exception e)
            {
                return new FailRequest(e.GetType(), e.Message);
            }
        }

        [HttpGet]
        [Route(Urls.Recipe.RecipeInstructions)]
        public async Task<IActionResult> RecipeInstructions(long id, bool? stepBreakdown = null)
        {
            try
            {
                var model = await _recipeRepo.GetAnalyzedRecipeInstructions(id, stepBreakdown);
                return Ok(model);
            }
            catch (Exception e)
            {
                return new FailRequest(e.GetType(), e.Message);
            }
        }
    }
}