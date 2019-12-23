using System.Collections.Generic;
using client_generator.OpenApi._3._0._1.JsonConverters;
using client_generator.OpenApi._3._0._1.Referable;

namespace client_generator.OpenApi._3._0._1
{
    public class Components
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
    }
}