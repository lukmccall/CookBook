namespace CookBook.API
{
    public static class Urls
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public const string ServiceUrl = "https://api.spoonacular.com";

        public const string ApiKey = "?apiKey=0d0a33fa92c74436ac2a6a799c097a49";

        public static class Auth
        {
            public const string Login = Base + "/auth/login";
            
            public const string Logout = Base + "/auth/logout";
            
            public const string Register = Base + "/auth/register";
            
            public const string Refresh = Base + "/auth/refresh";
            
        }
    }
}