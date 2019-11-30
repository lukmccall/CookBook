using System;
using System.Threading.Tasks;
using CookBook.API.Models;

namespace CookBook.API.Requests.External
{
    public interface IRecipeRepository
    {
        Task<RecipePriceBreakdown> GetRecipePriceBreakdown(long id);
    }

}