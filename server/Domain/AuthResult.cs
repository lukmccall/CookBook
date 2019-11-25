using System.Collections.Generic;

namespace CookBook.Domain
{
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