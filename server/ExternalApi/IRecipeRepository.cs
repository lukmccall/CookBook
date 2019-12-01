using System;
using System.Threading.Tasks;
using CookBook.ExternalApi.Models;

namespace CookBook.ExternalApi
{
    public interface IRecipeRepository
    {
        Task<RecipePriceBreakdown> GetRecipePriceBreakdown(long id);
    }

}