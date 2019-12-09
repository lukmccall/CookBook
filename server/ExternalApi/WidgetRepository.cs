using System.Threading.Tasks;
using CookBook.ExternalApi;
using System.Net.Http;
using System.Net;
using CookBook.Options;

public class WidgetRepository : IWidgetRepository
{
    private readonly ApiOptions _apiOptions;

    public WidgetRepository(ApiOptions apiOptions){
        _apiOptions = apiOptions;
    }
    public async Task<string> IngredientsById(long id, bool? defaultCss)
    {
        var recipeVisualization =
            await GetStringAsync(_apiOptions.Server + "/recipes/" + id + "/ingredientWidget?"
            + QueryParam(defaultCss, "defaultCss")
            + _apiOptions.ApiKey);

        return recipeVisualization;
    }

    public async Task<string> EquipmentbyId(long id, bool? defaultCss)
    {
        var recipeVisualization =
            await GetStringAsync(_apiOptions.Server + "/recipes/" + id + "/equipmentWidget?"
            + QueryParam(defaultCss, "defaultCss")
            + _apiOptions.ApiKey);

        return recipeVisualization;
    }

    public async Task<string> PriceBreakdownbyId(long id, bool? defaultCss)
    {
        var recipeVisualization =
            await GetStringAsync(_apiOptions.Server + "/recipes/" + id + "/priceBreakdownWidget?"
            + QueryParam(defaultCss, "defaultCss")
            + _apiOptions.ApiKey);

        return recipeVisualization;
    }

       public async Task<string> NutrionbyId(long id, bool? defaultCss)
    {
        var recipeVisualization =
            await GetStringAsync(_apiOptions.Server + "/recipes/" + id + "/nutritionWidget?"
            + QueryParam(defaultCss, "defaultCss")
            + _apiOptions.ApiKey);

        return recipeVisualization;
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
            throw new RepositoryException ("Widget endpoint does not exist");
        }

        throw new WebserviceException("Unexpected status from web service ");
    }

    private string QueryParam(dynamic obj, string param){
        return obj != null ? param + "=" + obj.ToString() + "&" : "";
    }
}