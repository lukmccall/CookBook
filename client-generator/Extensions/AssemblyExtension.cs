using System.Reflection;
using client_generator.Deserializer.Attributes;
using client_generator.Deserializer.Helpers;

namespace client_generator.Extensions
{
    public static class AssemblyExtension
    {

        public static OpenApiDeserializerAssemblyIterator CreateOpenApiDeserializerAssemblyIterator(
            this Assembly assembly)
        {
            return new OpenApiDeserializerAssemblyIterator(assembly.GetTypes());
        }

    }
}
