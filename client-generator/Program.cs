using client_generator.App;
using client_generator.App.Windows;
using client_generator.Deserializer;

namespace client_generator
{
    internal static class Program
    {

        private static void Main()
        {
            VersionedDeserializers.RegisterFromAssembly(typeof(Program).Assembly);
            AppController.Instance().InitApp<MenuWindow>();
        }

    }
}
