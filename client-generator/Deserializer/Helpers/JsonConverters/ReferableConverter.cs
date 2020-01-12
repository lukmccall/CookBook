using System;
using client_generator.Deserializer.Helpers.References;
using client_generator.OpenApi.Deserializer.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace client_generator.Deserializer.Helpers.JsonConverters
{
    public class ReferableConverter<T> : JsonConverter<IReferable<T>> where T : class
    {

        public override void WriteJson(JsonWriter writer, IReferable<T> value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.GetHashCode());
        }

        public override IReferable<T> ReadJson(JsonReader reader, Type objectType, IReferable<T> existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var item = JObject.Load(reader);
            if (item["$ref"] != null)
            {
                return new Reference<T>
                {
                    Ref = item["$ref"].ToString()
                };
            }

            return new ReferableDataWrapper<T>(item.ToObject<T>(serializer));
        }

    }
}
