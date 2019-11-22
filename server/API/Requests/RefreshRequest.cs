namespace CookBook.API.Requests
{
    public class RefreshRequest
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}