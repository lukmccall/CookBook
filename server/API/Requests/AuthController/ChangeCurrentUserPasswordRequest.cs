namespace CookBook.API.Requests.AuthController
{
    public class ChangeCurrentUserPasswordRequest
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}