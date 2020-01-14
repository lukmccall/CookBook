using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CookBook.Options;

namespace CookBook.ExternalApi
{
    public class WidgetRepository : IWidgetRepository
    {

        private readonly ApiOptions _apiOptions;

        private readonly HttpClient _httpClient;

        public WidgetRepository(ApiOptions apiOptions, HttpClient httpClient)
        {
            _apiOptions = apiOptions;
            _httpClient = httpClient;
        }

        public async Task<Widget> IngredientsById(long id, bool? defaultCss)
        {
            return await GetWidget("ingredientWidget", id, defaultCss);
        }

        public async Task<Widget> EquipmentById(long id, bool? defaultCss)
        {
            return await GetWidget("equipmentWidget", id, defaultCss);
        }


        public async Task<Widget> PriceBreakdownById(long id, bool? defaultCss)
        {
            return await GetWidget("priceBreakdownWidget", id, defaultCss);
        }

        public async Task<Widget> NutrionById(long id, bool? defaultCss)
        {
            return await GetWidget("nutritionWidget", id, defaultCss);
        }

        private async Task<string> GetStringAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await _httpClient.GetStringAsync(url);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new RepositoryException("Widget endpoint does not exist");
            }

            throw new WebserviceException("Unexpected status from web service ");
        }

        private async Task<Widget> GetWidget(string type, long id, bool? defaultCss)
        {
            return new Widget
            {
                Code = await GetStringAsync(
                    $"{_apiOptions.Server}/recipes/{id}/{type}?{QueryParam(defaultCss, "defaultCss")}{_apiOptions.ApiKey}"),
                DefaultCss = defaultCss ?? false
            };
        }

        private string QueryParam(dynamic obj, string param)
        {
            return obj != null ? param + "=" + obj.ToString() + "&" : "";
        }

    }
}
