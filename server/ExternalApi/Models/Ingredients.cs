using CookBook.API.Responses.RecipesController.InnerClasses;
using CookBook.Attributes;

namespace CookBook.ExternalApi.Models
{
    [Mappable(To = typeof(IngredientsResponse))]
    public class Ingredients
    {

        public Amount Amount { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

    }
}
