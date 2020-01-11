using System.Reflection;
using client_generator.Deserializer.Attributes;

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
