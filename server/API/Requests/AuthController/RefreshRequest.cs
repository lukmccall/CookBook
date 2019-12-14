namespace CookBook.API.Requests.AuthController
{
    public class RefreshRequest
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}