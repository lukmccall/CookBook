using CookBook.API.Responses.RecipesController.InnerClasses;
using CookBook.Attributes;

namespace CookBook.ExternalApi.Models
{
    [Mappable(To = typeof(UsResponse))]
    public class Us
    {

        public string Unit { get; set; }

        public float Value { get; set; }

    }
}
