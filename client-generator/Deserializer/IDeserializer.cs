using client_generator.Models;
using Newtonsoft.Json;

namespace client_generator.Deserializer
{
    public interface IDeserializer
    {

        OpenApiModel Deserialize(string json);

        void SetSettings(JsonSerializerSettings settings);

    }
}
