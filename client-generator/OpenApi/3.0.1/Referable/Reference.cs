using client_generator.OpenApi._3._0._1.JsonConverters;
using Newtonsoft.Json;

namespace client_generator.OpenApi._3._0._1.Referable
{
    public class Reference<T> : IReferable<T> where T : class
    {
        [JsonProperty("$ref")]
        public string Ref { get; set; }

        public T GetObject()
        {
            return null;
        }
        
    }
}