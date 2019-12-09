using System.Collections.Generic;

namespace CookBook.ExternalApi.Models
{
    public class RecipeInstruction
    {
        public string Name { get; set; }
        public IList<StepInstruction> Steps { get; set; }
    }
}