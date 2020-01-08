using System.Collections.Generic;

namespace CookBook.API.Responses.RecipesController.InnerClasses
{
    public class StepInstructionReponse
    {

        public IEnumerable<EquipmentResponse> Equipment { get; set; }

        public IEnumerable<PhotoResponse> Ingredients { get; set; }

        public long Number { get; set; }

        public string Step { get; set; }

    }
}
