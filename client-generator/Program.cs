using client_generator.App;
using client_generator.App.Windows;
using client_generator.Deserializer;
using client_generator.Generators;
using Newtonsoft.Json;

namespace client_generator
{
    internal static class Program
    {

        private static void Main()
        {
            VersionedDeserializers.RegisterFromAssembly(typeof(Program).Assembly);

            var model = VersionedDeserializers.Instance()
                .DeserializeFile("/Users/lukasz/studies/cis/CookBook/client-generator/openapi.json",
                    new JsonSerializerSettings());

            new Generator().Generate(model);

            // AppController.Instance().InitApp<MenuWindow>();
        }

    }
}
