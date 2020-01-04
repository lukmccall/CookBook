using client_generator.App;
using client_generator.App.Windows;

namespace client_generator
{
    internal static class Program
    {

        private static void Main()
        {
            // var jsonString = File.ReadAllText("/Users/lukasz/studies/cis/CookBook/client-generator/openapi.json");
            // var openApiFile = new Deserializer301(new JsonSerializerSettings()).Deserialize(jsonString);
            //
            // var generator = new Generator();
            // generator.Generate(openApiFile);

            AppController.Instance().InitApp<MenuWindow>();
        }

    }
}
