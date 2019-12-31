using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CookBook.API.Responses
{
    public class ValidationFailedResponse
    {
        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public bool Status => false;

        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public List<FiledErrors> Errors { get; set; }
    }
}