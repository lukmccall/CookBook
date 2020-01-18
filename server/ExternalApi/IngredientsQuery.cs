using System.Collections.Generic;

namespace CookBook.ExternalApi
{
    public class IngredientsQuery
    {

        public bool? IgnorePantry { get; set; }

        public bool? LimitLicense { get; set; }

        public int? Number { get; set; }

        public int? Ranking { get; set; }

        public int Page { get; set; } = 1;

        public IEnumerable<string> Ingredients { get; set; }

    }
}
