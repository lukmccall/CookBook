using client_generator.Deserializer;
using client_generator.Deserializer.Helpers;
using client_generator.Deserializer.Helpers.References;
using client_generator.Models;
using Newtonsoft.Json;

namespace client_generator.OpenApi.Deserializer.Helpers
{
    public class Reference<T> : IReferable<T> where T : class
    {
        [JsonProperty("$ref")]
        public string Ref { get; set; }

        public T GetObject()
        {
            return null;
        }

        public string GetRef()
        {
            return Ref;
        }
    }
}