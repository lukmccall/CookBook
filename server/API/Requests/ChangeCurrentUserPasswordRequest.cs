namespace CookBook.API.Requests
{
    public class ChangeCurrentUserPasswordRequest
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}