using client_generator.Models;

namespace client_generator.OpenApi._3._0._1.Referable
{
    public static class IReferableExtension
    {
        public static string GetName(this IReferable<Parameter> item)
        {
            return item?.GetObject()?.Name ?? item?.GetRef() ?? "unknown";
        }
    }
}