using System.ComponentModel.DataAnnotations;
using CookBook.Attributes;
using CookBook.Domain.AuthController;

namespace CookBook.API.Requests.AuthController
{    
    [Mappable(To = typeof(RegisterData))]
    public class RegisterRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}