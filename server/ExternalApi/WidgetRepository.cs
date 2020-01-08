using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CookBook.Options;

namespace CookBook.ExternalApi
{
    public class WidgetRepository : IWidgetRepository
    {

        private readonly ApiOptions _apiOptions;

        public WidgetRepository(ApiOptions apiOptions)
        {
            _apiOptions = apiOptions;
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

        private static async Task<string> GetStringAsync(string url)
        {
            // todo: use flyweight to get httpClient instance
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await httpClient.GetStringAsync(url);
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
