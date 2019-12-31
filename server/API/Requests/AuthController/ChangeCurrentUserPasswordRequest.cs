using System.ComponentModel.DataAnnotations;
using CookBook.Attributes;
using CookBook.Domain.AuthController;
using Newtonsoft.Json;

namespace CookBook.API.Requests.AuthController
{
    [Mappable(To = typeof(PasswordChangeData))]
    public class ChangeCurrentUserPasswordRequest
    {
        
        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public string OldPassword { get; set; }

        
        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public string NewPassword { get; set; }
    }
}