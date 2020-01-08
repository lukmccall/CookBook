using System.Collections.Generic;
using CookBook.ExternalApi.Models;

namespace CookBook.API.Responses.RecipesController
{
    public class RecipeResponse
    {

        public long Id { get; set; }

        public string Image { get; set; }

        public string ImageType { get; set; }

        public long Likes { get; set; }

        public int MissedIngredientCount { get; set; }

        public IList<Ingredient> MissedIngredients { get; set; }

        public string Title { get; set; }

        public IList<Ingredient> UnusedIngredients { get; set; }

        public int UsedIngredientCount { get; set; }

        public IList<Ingredient> UsedIngredients { get; set; }

    }
}
