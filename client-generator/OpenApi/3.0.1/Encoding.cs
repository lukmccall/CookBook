using System.Collections.Generic;
using client_generator.OpenApi._3._0._1.JsonConverters;
using client_generator.OpenApi._3._0._1.Referable;

namespace client_generator.OpenApi._3._0._1
{
    public class Encoding
    {
        public string ContentType { get; set; }
        public Dictionary<string, IReferable<Header>> Headers { get; set; }
        public string Style { get; set; }
        public bool Explode { get; set; }
        public bool AllowReserved { get; set; }
    }
}