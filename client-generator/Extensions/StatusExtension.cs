namespace client_generator.Extensions
{
    public static class StatusExtensions
    {

        public static bool WasSuccessful(this int status)
        {
            return status >= 200 && status < 400;
        }

    }
}
