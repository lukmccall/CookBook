using CookBook.API.Responses.RecipesController.InnerClasses;
using CookBook.Attributes;

namespace CookBook.ExternalApi.Models
{
    [Mappable(To = typeof(MetricResponse))]
    public class Metric
    {

        public string Unit { get; set; }

        public float Value { get; set; }

    }
}
