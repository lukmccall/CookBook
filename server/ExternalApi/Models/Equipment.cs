using CookBook.API.Responses.RecipesController.InnerClasses;
using CookBook.Attributes;

namespace CookBook.ExternalApi.Models
{
    [Mappable(To = typeof(EquipmentResponse))]
    public class Equipment
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public Temperature Temperature { get; set; }

    }
}
