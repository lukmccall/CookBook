using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.ExternalApi.Models;

namespace CookBook.ExternalApi
{
    public interface IRecipeRepository
    {
        Task<RecipePriceBreakdown> GetRecipePriceBreakdown(long id);
        Task<RecipeIngredients> GetRecipeIngredientsById(long id);
        Task<IList<RecipeInstruction>> GetAnalyzedRecipeInstructions(long id, bool? stepBreakdown);
        Task<IList<Recipe>> FindRecipeByIngredients(IngredientsQuery list);

    }

}