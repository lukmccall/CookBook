using System.Collections.Generic;

namespace CookBook.ExternalApi
{
    public class IngredientsQuery
    {

        public bool? IgnorePantry = null;

        public bool? LimitLicense = null;

        public int? Number = null;

        public int? Ranking = null;

        public IEnumerable<string> Ingredients { get; set; }

    }
}
