using System.Collections.Generic;
using CookBook.API.Responses.AuthController;
using CookBook.Attributes;

namespace CookBook.Domain
{
    [Mappable(To = typeof(AuthSuccessResponse))]
    [Mappable(To = typeof(AuthFailedResponse))]
    public class AuthResult
    {

        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public static AuthResult CreateWithSingleError(string error)
        {
            return new AuthResult
            {
                Errors = new[] {error}
            };
        }

    }
}
