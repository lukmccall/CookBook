using Newtonsoft.Json;

namespace client_generator.Models
{
    public class VersionGetter
    {

        [JsonProperty("openapi")]
        public string Version { get; set; }

    }
}
