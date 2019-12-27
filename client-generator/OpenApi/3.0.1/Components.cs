using System.Collections.Generic;
using client_generator.Models;
using client_generator.OpenApi._3._0._1.Referable;

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

//        public Dictionary<string, IReferable<>> SecuritySchemes { get; set; } // currently not supported

//        public Dictionary<string, IReferable<>> Links { get; set; } // currently not supported

//        public Dictionary<string, IReferable<>> Callbacks { get; set; } // currently not supported

        public void Accept(string path, IReferenceCollector referenceCollector)
        {
            if (Schemas != null)
            {
                foreach (var (key, value) in Schemas)
                {
                    referenceCollector.Visit($"{path}/{ReferableList.GetRefMap()[typeof(Schema)]}/{key}", value);
                }
            }

            if (Responses != null)
            {
                foreach (var (key, value) in Responses)
                {
                    referenceCollector.Visit($"{path}/{ReferableList.GetRefMap()[typeof(Schema)]}/{key}", value);
                }
            }

            if (Parameters != null)
            {
                foreach (var (key, value) in Parameters)
                {
                    referenceCollector.Visit($"{path}/{ReferableList.GetRefMap()[typeof(Schema)]}/{key}", value);
                    value.GetObject()?.Accept($"{path}/{ReferableList.GetRefMap()[typeof(Schema)]}/{key}",
                        referenceCollector);
                }
            }

            if (RequestBodies != null)
            {
                foreach (var (key, value) in RequestBodies)
                {
                    referenceCollector.Visit($"{path}/{ReferableList.GetRefMap()[typeof(Schema)]}/{key}", value);
                }
            }

            if (Headers != null)
            {
                foreach (var (key, value) in Headers)
                {
                    referenceCollector.Visit($"{path}/{ReferableList.GetRefMap()[typeof(Schema)]}/{key}", value);
                }
            }
        }
    }
}