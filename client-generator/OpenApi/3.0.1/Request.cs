using System.Collections.Generic;
using client_generator.Deserializer.Helpers.Collectors;

namespace client_generator.OpenApi._3._0._1
{
    public class Request : ICollectable<IReferenceCollector>
    {

        public string Description { get; set; }

        public Dictionary<string, MediaType> Content { get; set; }

        public bool? Required { get; set; }

        public void Accept(string path, IReferenceCollector collector)
        {
            if (Content != null)
            {
                foreach (var (key, content) in Content)
                {
                    content.Accept($"{path}/content/{key}", collector);
                }
            }
        }

    }
}
