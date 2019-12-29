using System.Collections.Generic;
using client_generator.Deserializer.Helpers.Collectors;
using client_generator.Deserializer.Helpers.References;

namespace client_generator.OpenApi._3._0._1
{
    public class Schema : ICollectable<IReferenceCollector>
    {

        public string Type { get; set; }

        public IEnumerable<string> Required { get; set; }

        public Dictionary<string, IReferable<Schema>> Properties { get; set; }

        public IReferable<Schema> Items { get; set; }

        public void Accept(string path, IReferenceCollector collector)
        {
            if (Items != null)
            {
                collector.Visit($"{path}/items", Items);
                Items.GetObject()?.Accept($"{path}/items", collector);
            }

            if (Properties != null)
            {
                foreach (var (key, property) in Properties)
                {
                    collector.Visit($"{path}/properties/{key}", property);
                    property.GetObject()?.Accept($"{path}/properties/{key}", collector);
                }
            }
        }

    }
}
