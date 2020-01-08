using System.Collections.Generic;

namespace CookBook.API.Responses.RecipesController.InnerClasses
{
    public class IngredientResponse
    {

        public string Aisle { get; set; }

        public float Amount { get; set; }

        public long Id { get; set; }

        public string Image { get; set; }

        public IEnumerable<string> MetaInformation { get; set; }

        public string Name { get; set; }

        public string Original { get; set; }

        public string OriginalName { get; set; }

        public string OriginalString { get; set; }

        public string Unit { get; set; }

        public string UnitLong { get; set; }

        public string UnitShort { get; set; }

    }
}
