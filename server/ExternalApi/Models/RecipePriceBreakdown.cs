using System.Collections.Generic;

namespace CookBook.ExternalApi.Models
{
    public class RecipePriceBreakdown
    {
        public IList<Ingredients> Ingredients { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalCostPerServing { get; set; }
    }
}