using System.Collections.Generic;
using CookBook.Attributes;
using CookBook.ExternalApi;

namespace CookBook.API.Requests.RecipesController
{
    [Mappable(To = typeof(IngredientsQuery))]
    public class IngredientsRequest
    {

        public bool? IgnorePantry = null;

        public bool? LimitLicense = null;

        public int? Number = null;

        public int? Ranking = null;

        public IEnumerable<string> Ingredients { get; set; }

    }
}
