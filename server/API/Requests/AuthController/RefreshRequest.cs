using System.ComponentModel.DataAnnotations;
using CookBook.Attributes;
using CookBook.Domain.AuthController;
using Newtonsoft.Json;

namespace CookBook.API.Requests.AuthController
{
    [Mappable(To = typeof(RefreshData))]
    public class RefreshRequest
    {
        
        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public string Token { get; set; }

        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public string RefreshToken { get; set; }
    }
}