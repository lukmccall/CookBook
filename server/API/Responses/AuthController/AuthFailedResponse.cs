using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CookBook.API.Responses.AuthController
{
    public class AuthFailedResponse
    {
        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public bool Success { get; set; }

        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public IEnumerable<string> Errors { get; set; }
    }
}