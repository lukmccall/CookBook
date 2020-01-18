namespace CookBook.API
{
    public static class Urls
    {

        private const string Root = "api";

        private const string Version = "v1";

        private const string Base = Root + "/" + Version;

        public static class Auth
        {

            public const string Login = Base + "/auth/login";

            public const string Logout = Base + "/auth/logout";

            public const string Register = Base + "/auth/register";

            public const string Refresh = Base + "/auth/refresh";

        }

        public static class User
        {

            public const string GetCurrentUser = Base + "/users/me/get";

            public const string UpdateCurrentUser = Base + "/users/me/update";

            public const string ChangeCurrentUserPassword = Base + "/user/me/changePassword";

            public const string ChangePicture = Base + "/user/changePicture";

        }

        public static class Comments
        {

            public const string GetComments = Base + "/comment/get/{id}";

            public const string AddComment = Base + "/comment/add/{id}";

        }

        public static class Recipe
        {

            public const string PriceBreakdown = "/recipePriceBreakdown/{id}";

            public const string RecipeIngredients = "/recipeIngredients/{id}";

            public const string SearchByIngredients = "/searchByIngredients";

            public const string RecipeInstructions = "/recipeInstructions/{id}";

        }

        public static class Widget
        {

            public const string RecipeVisualization = "/recipeVisualization/{id}";

            public const string EquipmentVisualization = "/equipmentVisualization/{id}";

            public const string PriceBreakDownVisualization = "/priceBreakdownVisualization/{id}";

            public const string NutrionVisualization = "/nutrionVisualization/{id}";

        }

    }
}
