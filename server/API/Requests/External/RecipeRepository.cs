using System.Threading.Tasks;
using CookBook.API.Models;
using CookBook.API;
using CookBook.API.Requests.External;
using System.Net.Http;
using Newtonsoft.Json;

public class RecipeRepository : IRecipeRepository
{
    public async Task<RecipePriceBreakdown> GetRecipePriceBreakdown(long id)
    {
        var priceBreakdownJson =
            await GetStringAsync(Urls.ServiceUrl + "/recipes/" + id + "/priceBreakdownWidget.json" + Urls.ApiKey);
        var priceBreakdown = JsonConvert.DeserializeObject<RecipePriceBreakdown>(priceBreakdownJson);

        return priceBreakdown;
    }

    private static async Task<string> GetStringAsync(string url)
    {
        using var httpClient = new HttpClient();
        return await httpClient.GetStringAsync(url);
    }
}