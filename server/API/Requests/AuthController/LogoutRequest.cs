using System.ComponentModel.DataAnnotations;
using CookBook.Attributes;
using CookBook.Domain.AuthController;
using Newtonsoft.Json;

namespace CookBook.API.Requests.AuthController
{
    [Mappable(To = typeof(LogoutData))]
    public class LogoutRequest
    {

        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public string Token { get; set; }

    }
}
