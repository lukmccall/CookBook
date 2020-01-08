using System;

namespace CookBook.ExternalApi
{
    public class WebserviceException : Exception
    {

        public WebserviceException()
        {
        }

        public WebserviceException(string message)
            : base(message)
        {
        }

        public WebserviceException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
