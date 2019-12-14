using CookBook.Attributes;
using CookBook.Domain.AuthController;

namespace CookBook.API.Requests.AuthController
{
    [Mappable(To = typeof(PasswordChangeData))]
    public class ChangeCurrentUserPasswordRequest
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}