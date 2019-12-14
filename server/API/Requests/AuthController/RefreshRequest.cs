using CookBook.Attributes;
using CookBook.Domain.AuthController;

namespace CookBook.API.Requests.AuthController
{
    [Mappable(To = typeof(RefreshData))]
    public class RefreshRequest
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}