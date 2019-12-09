using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Options
{
    public class ApiOptions
    {
        public string Server { get; set; }

        public string ApiKey { get; set; }
    }
}