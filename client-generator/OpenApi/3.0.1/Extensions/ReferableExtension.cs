using client_generator.Deserializer.Helpers.References;

namespace client_generator.OpenApi._3._0._1.Extensions
{
    public static class ReferableExtension
    {

        public static string GetName(this IReferable<Parameter> item)
        {
            return item?.GetObject()?.Name ?? item?.GetRef() ?? "unknown";
        }

    }
}
