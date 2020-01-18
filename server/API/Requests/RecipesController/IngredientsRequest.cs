using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CookBook.Attributes;
using CookBook.ExternalApi;

namespace CookBook.API.Requests.RecipesController
{
    [Mappable(To = typeof(IngredientsQuery))]
    public class IngredientsRequest
    {

        public bool? IgnorePantry { get; set; }

        public bool? LimitLicense { get; set; }

        public int? Number { get; set; }

        public int? Ranking { get; set; }

        public int Page { get; set; } = 1;

        [Required]
        public IEnumerable<string> Ingredients { get; set; }

    }
}
