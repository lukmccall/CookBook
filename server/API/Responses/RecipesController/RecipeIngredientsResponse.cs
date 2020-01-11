using System.Collections.Generic;
using CookBook.API.Responses.RecipesController.InnerClasses;

namespace CookBook.API.Responses.RecipesController
{
    public class RecipeIngredientsResponse
    {

        public IEnumerable<IngredientsResponse> Ingredients { get; set; }

    }
}
