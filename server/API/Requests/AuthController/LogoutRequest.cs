using CookBook.Attributes;
using CookBook.Domain.AuthController;

namespace CookBook.API.Requests.AuthController
{
    [Mappable(To = typeof(LogoutData))]
    public class LogoutRequest
    {
        public string Token { get; set; }
    }
}