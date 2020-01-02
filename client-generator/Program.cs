using System.Collections.Generic;
using System.IO;
using client_generator.Deserializer.Helpers.JsonConverters;
using client_generator.Generators;
using client_generator.OpenApi._3._0._1;
using client_generator.OpenApi._3._0._1.Deserializer;
using Newtonsoft.Json;

namespace client_generator
{
    internal static class Program
    {

        private static void Main()
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
            
            var generator = new GeneratorContext(new TsGenerator());
            openApiFile.Generate(generator);
            
            
        }

    }
}
