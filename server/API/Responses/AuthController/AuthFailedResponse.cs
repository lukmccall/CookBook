using System.Collections.Generic;

namespace CookBook.API.Responses.AuthController
{
    public class AuthFailedResponse
    {
        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}