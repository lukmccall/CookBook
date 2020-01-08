using CookBook.API.Responses.RecipesController.InnerClasses;
using CookBook.Attributes;

namespace CookBook.ExternalApi.Models
{
    [Mappable(To = typeof(TemperatureResponse))]
    public class Temperature
    {

        public float Number { get; set; }

        public string Unit { get; set; }

    }
}
