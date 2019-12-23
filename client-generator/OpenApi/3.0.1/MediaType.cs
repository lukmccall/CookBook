using System;
using System.Collections.Generic;
using client_generator.OpenApi._3._0._1.JsonConverters;
using client_generator.OpenApi._3._0._1.Referable;

namespace client_generator.OpenApi._3._0._1
{
    public class MediaType
    {
        public IReferable<Schema> Schema { get; set; }

        public Dictionary<string, Encoding> Encoding { get; set; }
//        public Object example { get; set; } // currently not supported
//        public Object examples { get; set; } // currently not supported
    }
}