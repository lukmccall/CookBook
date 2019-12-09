using System.Collections.Generic;

namespace CookBook.ExternalApi.Models
{
    public class RecipeIngredients
    {
        public IList<Ingredients> Ingredients { get; set; }
    }
}