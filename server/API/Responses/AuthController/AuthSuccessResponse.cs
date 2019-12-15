using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CookBook.API.Responses.AuthController
{
    public class AuthSuccessResponse
    {
        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public string Token { get; set; }

        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public string RefreshToken { get; set; }

        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public bool Success { get; set; }
    }
}