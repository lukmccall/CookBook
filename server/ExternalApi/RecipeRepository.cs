using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CookBook.ExternalApi.Models;
using CookBook.Options;
using Newtonsoft.Json;

namespace CookBook.ExternalApi
{
    public class RecipeRepository : IRecipeRepository
    {

        private readonly ApiOptions _apiOptions;

        private readonly HttpClient _httpClient;

        public RecipeRepository(ApiOptions apiOptions, HttpClient httpClient)
        {
            _apiOptions = apiOptions;
            _httpClient = httpClient;
        }

        public async Task<RecipePriceBreakdown> GetRecipePriceBreakdown(long id)
        {
            var priceBreakdownJson =
                await GetStringAsync(_apiOptions.Server + "/recipes/" + id + "/priceBreakdownWidget.json?" +
                                     _apiOptions.ApiKey);
            var priceBreakdown = JsonConvert.DeserializeObject<RecipePriceBreakdown>(priceBreakdownJson);

            return priceBreakdown;
        }

        public async Task<RecipeIngredients> GetRecipeIngredientsById(long id)
        {
            var recipeIngredientsJson =
                await GetStringAsync(_apiOptions.Server + "/recipes/" + id + "/ingredientWidget.json?" +
                                     _apiOptions.ApiKey);
            var recipeIngredients = JsonConvert.DeserializeObject<RecipeIngredients>(recipeIngredientsJson);

            return recipeIngredients;
        }

        public async Task<IList<Recipe>> FindRecipeByIngredients(IngredientsQuery list)
        {
            var ingredientsConcat = string.Join(",+", list.Ingredients);
            var url = _apiOptions.Server + "/recipes/findByIngredients?"
                                         + QueryParam(ingredientsConcat, "ingredients")
                                         + QueryParam(list.LimitLicense, "limitLicense")
                                         + QueryParam(list.Number ?? 25, "number")
                                         + QueryParam(list.Ranking, "ranking")
                                         + QueryParam(list.IgnorePantry, "ignorePantry")
                                         + _apiOptions.ApiKey;
            var recipesJson = await GetStringAsync(url);

            return JsonConvert.DeserializeObject<IList<Recipe>>(recipesJson);
        }

        public async Task<IList<RecipeInstruction>> GetAnalyzedRecipeInstructions(long id, bool? stepBreakdown)
        {
            var instructionJson =
                await GetStringAsync(_apiOptions.Server + "/recipes/" + id + "/analyzedInstructions?"
                                     + QueryParam(stepBreakdown, "stepBreakdown")
                                     + _apiOptions.ApiKey);

            var instruction = JsonConvert.DeserializeObject<IList<RecipeInstruction>>(instructionJson);

            return instruction;
        }

        private async Task<string> GetStringAsync(string url)
        {
            // todo: use flyweight to get httpClient instance
            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await _httpClient.GetStringAsync(url);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new RepositoryException("Recipe endpoint does not exist");
            }

            throw new WebserviceException("Unexpected status from web service");
        }

        private string QueryParam(dynamic obj, string param)
        {
            return obj != null ? param + "=" + obj.ToString() + "&" : "";
        }

    }
}
