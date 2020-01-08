using System.Collections.Generic;
using CookBook.API.Responses.RecipesController;
using CookBook.Attributes;

namespace CookBook.ExternalApi.Models
{
    [Mappable(To = typeof(RecipeIngredientsResponse))]
    public class RecipeIngredients
    {

        public IList<Ingredients> Ingredients { get; set; }

    }
}
