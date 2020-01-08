using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CookBook.API.Responses
{
    public class FiledErrors
    {

        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public string Field { get; set; }

        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public IEnumerable<string> Messages { get; set; }

    }
}
