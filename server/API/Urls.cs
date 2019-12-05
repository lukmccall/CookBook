namespace CookBook.API
{
    public static class Urls
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Auth
        {
            public const string Login = Base + "/auth/login";

            public const string Logout = Base + "/auth/logout";

            public const string Register = Base + "/auth/register";

            public const string Refresh = Base + "/auth/refresh";
        }

        public static class User
        {
            public const string GetCurrentUser = Base + "/users/me";

            public const string UpdateCurrentUser = Base + "/users/me";

            public const string ChangeCurrentUserPassword = Base + "/user/me/change-password";
        }
    }
}