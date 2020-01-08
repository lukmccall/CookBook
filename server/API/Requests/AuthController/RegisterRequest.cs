using System.ComponentModel.DataAnnotations;
using CookBook.Attributes;
using CookBook.Domain.AuthController;
using Newtonsoft.Json;

namespace CookBook.API.Requests.AuthController
{
    [Mappable(To = typeof(RegisterData))]
    public class RegisterRequest
    {

        [EmailAddress]
        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public string Email { get; set; }

        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public string UserName { get; set; }

        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public string Password { get; set; }

    }
}
