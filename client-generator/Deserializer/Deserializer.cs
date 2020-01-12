using System.Collections.Generic;
using client_generator.Models;
using Newtonsoft.Json;

namespace client_generator.Deserializer
{
    public abstract class Deserializer<T> : IDeserializer
    {

        private JsonSerializerSettings _settings = new JsonSerializerSettings();

        public OpenApiModel Deserialize(string json)
        {
            _settings.Converters = GetConverters();
            var versionedModel = JsonConvert.DeserializeObject<T>(json, _settings);
            return Convert(versionedModel);
        }

        public void SetSettings(JsonSerializerSettings settings)
        {
            _settings = settings;
        }

        protected virtual IList<JsonConverter> GetConverters()
        {
            return new List<JsonConverter>();
        }

        protected abstract OpenApiModel Convert(T versionedModel);

    }
}
