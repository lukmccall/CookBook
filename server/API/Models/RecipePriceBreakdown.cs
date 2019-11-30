using System.Collections.Generic;

namespace CookBook.API.Models
{
    public class RecipePriceBreakdown
    {
        public IList<Ingredients> ingredients {get;set;}
        public decimal TotalCost {get; set;}
        public decimal TotalCostPerServing{get;set;}
    }
}

