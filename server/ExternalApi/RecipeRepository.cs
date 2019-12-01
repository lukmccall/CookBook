using System.Threading.Tasks;
using CookBook.ExternalApi.Models;
using CookBook.ExternalApi;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using CookBook.Options;

public class RecipeRepository : IRecipeRepository
{
    private readonly ApiOptions _apiOptions;

    public RecipeRepository(ApiOptions apiOptions){
        _apiOptions = apiOptions;
    }
    public async Task<RecipePriceBreakdown> GetRecipePriceBreakdown(long id)
    {
        var priceBreakdownJson =
            await GetStringAsync(_apiOptions.Server + "/recipes/" + id + "/priceBreakdownWidget.json" + _apiOptions.ApiKey);
        var priceBreakdown = JsonConvert.DeserializeObject<RecipePriceBreakdown>(priceBreakdownJson);

        return priceBreakdown;
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
            throw new RepositoryException ("Recipe Price Breakdown does not exist");
        }

        throw new RepositoryException("Unexpected status from web service");
    }
}