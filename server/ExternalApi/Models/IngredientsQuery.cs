using System.Collections.Generic;

namespace CookBook.ExternalApi.Models
{
    public class IngredientsQuery
    {
        public IList<string> ingredients {get; set;}
        public int? number = null;
        public bool? limitLicense = null;
        public int? ranking = null;
        public bool? ignorePantry = null;
    }
}