using client_generator.Deserializer;
using client_generator.Deserializer.Attributes;
using client_generator.Models;
using Newtonsoft.Json;

namespace client_generator_tests.Helpers
{
    [OpenApiDeserializer(Version = "-1")]
    public class FakeDeserializer : IDeserializer
    {

        public static int Construction { get; private set; }
        
        public FakeDeserializer()
        {
            Construction++;
        }

        public OpenApiModel Deserialize(string json)
        {
            throw new System.NotImplementedException();
        }

        public void SetSettings(JsonSerializerSettings settings)
        {
            throw new System.NotImplementedException();
        }

    }
}
