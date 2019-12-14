namespace CookBook.API.Responses.AuthController
{
    public class AuthSuccessResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public bool Success { get; set; }
    }
}