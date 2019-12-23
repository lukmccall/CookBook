using System.Collections.Generic;
using client_generator.OpenApi._3._0._1.JsonConverters;
using client_generator.OpenApi._3._0._1.Referable;

namespace client_generator.OpenApi._3._0._1
{
    public class Operation
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

    }
}