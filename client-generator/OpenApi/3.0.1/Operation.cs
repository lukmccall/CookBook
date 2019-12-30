using System.Collections.Generic;
using client_generator.Deserializer.Helpers.Collectors;
using client_generator.Deserializer.Helpers.References;
using client_generator.OpenApi._3._0._1.Extensions;

namespace client_generator.OpenApi._3._0._1
{
    public class Operation : ICollectable<IReferenceCollector>
    {

        public List<string> Tags { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

//        public Object ExternalDocs { get; set; } // currently not supported
        public string OperationId { get; set; }

        public IEnumerable<IReferable<Parameter>> Parameters { get; set; }

        public IReferable<Request> RequestBody { get; set; }

        public Dictionary<string, IReferable<Response>> Responses { get; set; }

//        public Object Callbacks { get; set; } // currently not supported

        public bool Deprecated { get; set; }

        public Dictionary<string, IEnumerable<string>> Security { get; set; }

//        public Object Servers { get; set; } // currently not supported

        public void Accept(string path, IReferenceCollector collector)
        {
            if (Parameters != null)
            {
                foreach (var parameter in Parameters)
                {
                    collector.Visit($"{path}/parameters/{parameter.GetName()}", parameter);
                    parameter.GetObject()?.Accept($"{path}/parameters/{parameter.GetName()}", collector);
                }
            }

            if (RequestBody != null)
            {
                collector.Visit($"{path}/requestBody", RequestBody);
                RequestBody.GetObject().Accept($"{path}/requestBody", collector);
            }

            if (Responses != null)
            {
                foreach (var (key, response) in Responses)
                {
                    collector.Visit($"{path}/responses/{key}", response);
                }
            }
        }

    }
}
