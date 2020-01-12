using System.Collections.Generic;
using client_generator.Deserializer.Helpers.Collectors;
using client_generator.Deserializer.Helpers.References;

namespace client_generator.OpenApi._3._0._1
{
    public class Response : ICollectable<IReferenceCollector>
    {

        public string Description { get; set; }

        public Dictionary<string, IReferable<Header>> Headers { get; set; }

        public Dictionary<string, MediaType> Content { get; set; }

//        public Object Links { get; set; } // currently not supported
//        public Object Callbacks { get; set; } // currently not supported
        public bool Deprecated { get; set; }

        public void Accept(string path, IReferenceCollector collector)
        {
            if (Headers != null)
            {
                foreach (var (key, header) in Headers)
                {
                    collector.Visit($"{path}/headers/{key}", header);
                    header.GetObject()?.Accept($"{path}/headers/{key}", collector);
                }
            }

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
