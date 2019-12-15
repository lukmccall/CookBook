using System.ComponentModel.DataAnnotations;
using CookBook.Attributes;
using CookBook.Domain.AuthController;

namespace CookBook.API.Requests.AuthController
{
    [Mappable(To = typeof(LoginData))]
    public class LoginRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}