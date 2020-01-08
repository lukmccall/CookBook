using System.Collections.Generic;
using CookBook.API.Responses.RecipesController.InnerClasses;
using CookBook.Attributes;

namespace CookBook.ExternalApi.Models
{
    [Mappable(To = typeof(StepInstructionReponse))]
    public class StepInstruction
    {

        public IList<Equipment> Equipment { get; set; }

        public IList<Photo> Ingredients { get; set; }

        public long Number { get; set; }

        public string Step { get; set; }

    }
}
