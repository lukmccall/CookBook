using System.Collections.Generic;
using CookBook.API.Responses.RecipesController.InnerClasses;

namespace CookBook.API.Responses.RecipesController
{
    public class RecipesPriceBreakdownResponse
    {

        public IEnumerable<IngredientsResponse> Ingredients { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalCostPerServing { get; set; }

    }
}
