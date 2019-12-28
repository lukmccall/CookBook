using System.Collections.Generic;
using client_generator.OpenApi._3._0._1.Referable;

namespace client_generator.OpenApi._3._0._1
{
    public class OpenApiFile : ICollectable<IReferenceCollector>
    {
        public string OpenApi { get; set; }

        public Info Info { get; set; }

//        public Object Serves { get; set; } // currently not supported 

        public Dictionary<string, PathItem> Paths { get; set; }

        public Components Components { get; set; }

        public IEnumerable<Dictionary<string, IEnumerable<string>>> Security { get; set; }

//        public Object Tags { get; set; } // currently not supported 

//        public Object ExternalDocs { get; set; } // currently not supported 

        public void Accept(string path, IReferenceCollector referenceCollector)
        {
            Components?.Accept($"{path}/components", referenceCollector);

            if (Paths != null)
            {
                foreach (var (key, value) in Paths)
                {
                    value?.Accept($"{path}/paths/{key}", referenceCollector);
                }
            }
        }
    }
}