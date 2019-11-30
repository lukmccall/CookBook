using System.ComponentModel.DataAnnotations;

namespace CookBook.API.Requests
{
    public class RegisterRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}