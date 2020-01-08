using System.Collections.Generic;
using CookBook.API.Responses.RecipesController.InnerClasses;

namespace CookBook.API.Responses.RecipesController
{
    public class RecipeInstructionResponse
    {

        public string Name { get; set; }

        public IEnumerable<StepInstructionReponse> Steps { get; set; }

    }
}
