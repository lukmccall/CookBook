using client_generator.Deserializer.Helpers.Collectors;
using client_generator.Deserializer.Helpers.References;

namespace client_generator.OpenApi._3._0._1
{
    public class Header : ICollectable<IReferenceCollector>
    {

        public string Description { get; set; }

        public bool? Required { get; set; }

        public bool? Deprecated { get; set; }

        public bool? AllowEmptyValue { get; set; }

        public string Style { get; set; }

        public bool? Explode { get; set; }

        public bool? AllowReserved { get; set; }

        public IReferable<Schema> Schema { get; set; }

        public void Accept(string path, IReferenceCollector collector)
        {
            collector.Visit($"{path}/schema", Schema);
            Schema?.GetObject()?.Accept($"{path}/schema", collector);
        }

    }
}
