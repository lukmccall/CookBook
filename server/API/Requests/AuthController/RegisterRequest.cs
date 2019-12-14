using System.ComponentModel.DataAnnotations;

namespace CookBook.API.Requests.AuthController
{
    public class RegisterRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}