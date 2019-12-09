using System.Threading.Tasks;
using CookBook.ExternalApi.Models;
using CookBook.ExternalApi;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using CookBook.Options;
using System.Collections.Generic;

public class RecipeRepository : IRecipeRepository
{
    private readonly ApiOptions _apiOptions;

    public RecipeRepository(ApiOptions apiOptions){
        _apiOptions = apiOptions;
    }
    public async Task<RecipePriceBreakdown> GetRecipePriceBreakdown(long id)
    {
        var priceBreakdownJson =
            await GetStringAsync(_apiOptions.Server + "/recipes/" + id + "/priceBreakdownWidget.json?" + _apiOptions.ApiKey);
        var priceBreakdown = JsonConvert.DeserializeObject<RecipePriceBreakdown>(priceBreakdownJson);

        return priceBreakdown;
    }
    public async Task<RecipeIngredients> GetRecipeIngredientsById(long id)
    {
        var recipeIngredientsJson =
            await GetStringAsync(_apiOptions.Server + "/recipes/" + id + "/ingredientWidget.json?" + _apiOptions.ApiKey);
        var recipeIngredients = JsonConvert.DeserializeObject<RecipeIngredients>(recipeIngredientsJson);

        return recipeIngredients;
    }

    public async Task<IList<Recipe>> FindRecipeByIngredients(IngredientsQuery list)
    {
        string ingredientsConcat = string.Join(",+", list.ingredients);
        var recipesJson =
            await GetStringAsync(_apiOptions.Server + "/recipes/findByIngredients?"
            + QueryParam(ingredientsConcat, "ingredients")
            + QueryParam(list.limitLicense, "limitLicense")
            + QueryParam(list.number, "number")
            + QueryParam(list.ranking, "ranking")
            + QueryParam(list.ignorePantry, "ignorePantry")
            + _apiOptions.ApiKey);

        var recipes = JsonConvert.DeserializeObject<IList<Recipe>>(recipesJson);

        return recipes;
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

    private static async Task<string> GetStringAsync(string url)
    {
        using var httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(url);
         if(response.StatusCode == HttpStatusCode.OK)
        {
            return await httpClient.GetStringAsync(url);
        }
        else if(response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new RepositoryException ("Recipe endpoint does not exist");
        }

        throw new WebserviceException("Unexpected status from web service");
    }

    private string QueryParam(dynamic obj, string param){
        return obj != null ? param + "=" + obj.ToString() + "&" : "";
    }
}