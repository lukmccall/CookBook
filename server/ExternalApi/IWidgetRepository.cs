using System.Threading.Tasks;

namespace CookBook.ExternalApi
{
    public interface IWidgetRepository
    {
        Task<string> IngredientsById(long id, bool? defaultCss);
        Task<string> EquipmentbyId(long id, bool? defaultCss);
        Task<string> PriceBreakdownbyId(long id, bool? defaultCss);
        Task<string> NutrionbyId(long id, bool? defaultCss);
    }

}