using System.Collections.Generic;
using CookBook.API.Responses.RecipesController;
using CookBook.Attributes;

namespace CookBook.ExternalApi.Models
{
    [Mappable(To = typeof(RecipesPriceBreakdownResponse))]
    public class RecipePriceBreakdown
    {

        public IList<Ingredients> Ingredients { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalCostPerServing { get; set; }

    }
}
