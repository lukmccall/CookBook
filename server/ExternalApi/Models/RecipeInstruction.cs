using System.Collections.Generic;
using CookBook.API.Responses.RecipesController;
using CookBook.Attributes;

namespace CookBook.ExternalApi.Models
{
    [Mappable(To = typeof(RecipesPriceBreakdownResponse))]
    public class RecipeInstruction
    {

        public string Name { get; set; }

        public IList<StepInstruction> Steps { get; set; }

    }
}
