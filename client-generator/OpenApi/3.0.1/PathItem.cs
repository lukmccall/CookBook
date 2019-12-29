using System.Collections.Generic;
using client_generator.Deserializer.Helpers.Collectors;
using client_generator.Deserializer.Helpers.References;
using client_generator.OpenApi._3._0._1.Extensions;
using Newtonsoft.Json;

namespace client_generator.OpenApi._3._0._1
{
    public class PathItem : ICollectable<IReferenceCollector>
    {

        [JsonProperty("$ref")]
        public string Ref { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

//        public Object Servers { get; set; } // currently not supported

        public IEnumerable<IReferable<Parameter>> Parameters { get; set; }

        public Operation Get { get; set; }

        public Operation Put { get; set; }

        public Operation Post { get; set; }

        public Operation Delete { get; set; }

        public Operation Options { get; set; }

        public Operation Head { get; set; }

        public Operation Patch { get; set; }

        public Operation Trace { get; set; }

//        public Object servers { get; set; } // currently noe supported

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

            Get?.Accept($"{path}/get", collector);
            Put?.Accept($"{path}/put", collector);
            Post?.Accept($"{path}/post", collector);
            Delete?.Accept($"{path}/delete", collector);
            Options?.Accept($"{path}/options", collector);
            Head?.Accept($"{path}/head", collector);
            Patch?.Accept($"{path}/patch", collector);
            Trace?.Accept($"{path}/trace", collector);
        }

    }
}
