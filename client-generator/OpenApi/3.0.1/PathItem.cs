using System.Collections.Generic;
using client_generator.OpenApi._3._0._1.JsonConverters;
using client_generator.OpenApi._3._0._1.Referable;
using Newtonsoft.Json;

namespace client_generator.OpenApi._3._0._1
{
    public class PathItem
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

    }
}