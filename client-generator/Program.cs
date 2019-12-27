using System;
using System.Collections.Generic;
using System.IO;
using client_generator.OpenApi._3._0._1;
using client_generator.OpenApi._3._0._1.Deserializer;
using client_generator.OpenApi._3._0._1.JsonConverters;
using Newtonsoft.Json;

namespace client_generator
{
    static class Program
    {
        static void Main()
        {
            var converters = new List<JsonConverter>
            {
                new ReferableConverter<Parameter>(),
                new ReferableConverter<Schema>(),
                new ReferableConverter<Request>(),
                new ReferableConverter<Response>(),
                new ReferableConverter<Header>()

            };

            var jsonString = File.ReadAllText("/Users/lukasz/studies/cis/CookBook/client-generator/openapi.json");
//            var jsonString = "{\"name\": \"id\",\"in\": \"path\",\"required\": true,\"schema\": {\"type\": \"integer\",\"format\": \"int64\"}}";
            var openApiFile = new Deserializer301(new JsonSerializerSettings()).Deserialize(jsonString);

            var result = JsonConvert.SerializeObject(openApiFile, Formatting.Indented, new JsonSerializerSettings
            {
                Converters = converters,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            });

            Console.WriteLine(result);
        }
    }
}