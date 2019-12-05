using System.Linq;
using CookBook.Models;
using Microsoft.AspNetCore.Http;

namespace CookBook.Extensions
{
    public static class UserExtension
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            return httpContext.User?.Claims.Single(x => x.Type == "id").Value;
        }
    }
}