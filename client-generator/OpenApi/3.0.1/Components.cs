using System.Collections.Generic;
using client_generator.Deserializer.Helpers.Collectors;
using client_generator.Deserializer.Helpers.References;

namespace client_generator.OpenApi._3._0._1
{
    public class Components : ICollectable<IReferenceCollector>
    {

        public Dictionary<string, IReferable<Schema>> Schemas { get; set; }

        public Dictionary<string, IReferable<Response>> Responses { get; set; }

        public Dictionary<string, IReferable<Parameter>> Parameters { get; set; }

//        public Dictionary<string, IReferable<>> Examples { get; set; } // currently not supported

        public Dictionary<string, IReferable<Request>> RequestBodies { get; set; }

        public Dictionary<string, IReferable<Header>> Headers { get; set; }

        public Dictionary<string, IReferable<SecurityScheme>> SecuritySchemes { get; set; }

//        public Dictionary<string, IReferable<>> Links { get; set; } // currently not supported

//        public Dictionary<string, IReferable<>> Callbacks { get; set; } // currently not supported

        public void Accept(string path, IReferenceCollector referenceCollector)
        {
            if (Schemas != null)
            {
                foreach (var (key, value) in Schemas)
                {
                    referenceCollector.Visit($"{path}/schemas/{key}", value);
                    value.GetObject()?.Accept($"{path}/schemas/{key}", referenceCollector);
                }
            }

            if (Responses != null)
            {
                foreach (var (key, value) in Responses)
                {
                    referenceCollector.Visit($"{path}/responses/{key}", value);
                    value.GetObject()?.Accept($"{path}/responses/{key}", referenceCollector);
                }
            }

            if (Parameters != null)
            {
                foreach (var (key, value) in Parameters)
                {
                    referenceCollector.Visit($"{path}/parameters/{key}", value);
                    value.GetObject()?.Accept($"{path}/parameters/{key}",
                        referenceCollector);
                }
            }

            if (RequestBodies != null)
            {
                foreach (var (key, value) in RequestBodies)
                {
                    referenceCollector.Visit($"{path}/requestBodies/{key}", value);
                }
            }

            if (Headers != null)
            {
                foreach (var (key, value) in Headers)
                {
                    referenceCollector.Visit($"{path}/requestBodies/{key}", value);
                }
            }

            if (SecuritySchemes != null)
            {
                foreach (var (key, value) in SecuritySchemes)
                {
                    referenceCollector.Visit($"{path}/securitySchemas/{key}", value);
                }
            }
        }

    }
}
