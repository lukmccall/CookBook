using System.Threading.Tasks;

namespace CookBook.ExternalApi
{
    public interface IWidgetRepository
    {

        Task<Widget> IngredientsById(long id, bool? defaultCss);

        Task<Widget> EquipmentById(long id, bool? defaultCss);

        Task<Widget> PriceBreakdownById(long id, bool? defaultCss);

        Task<Widget> NutrionById(long id, bool? defaultCss);

    }
}
