using System.Collections.Generic;
using client_generator.Deserializer.Helpers.Collectors;
using client_generator.Deserializer.Helpers.References;

namespace client_generator.OpenApi._3._0._1
{
    public class MediaType : ICollectable<IReferenceCollector>
    {

        public IReferable<Schema> Schema { get; set; }

        public Dictionary<string, Encoding> Encoding { get; set; }

//        public Object example { get; set; } // currently not supported
//        public Object examples { get; set; } // currently not supported
        public void Accept(string path, IReferenceCollector collector)
        {
            collector.Visit($"{path}/schema", Schema);
            Schema?.GetObject()?.Accept($"{path}/schema", collector);

            if (Encoding != null)
            {
                foreach (var (key, encoding) in Encoding)
                {
                    encoding.Accept($"{path}/encoding/{key}", collector);
                }
            }
        }

    }
}
