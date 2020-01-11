using CookBook.API.Responses.RecipesController.InnerClasses;
using CookBook.Attributes;

namespace CookBook.ExternalApi.Models
{
    [Mappable(To = typeof(AmountResponse))]
    public class Amount
    {

        public Metric Metric { get; set; }

        public Us Us { get; set; }

    }
}
