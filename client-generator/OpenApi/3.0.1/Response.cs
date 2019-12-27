using System;
using System.Collections.Generic;
using client_generator.Models;
using client_generator.OpenApi._3._0._1.JsonConverters;
using client_generator.OpenApi._3._0._1.Referable;

namespace client_generator.OpenApi._3._0._1
{
    public class Response
    {
        public string Description { get; set; }
        public Dictionary<string, IReferable<Header>> Headers { get; set; }
        public Dictionary<string, MediaType> Content { get; set; }
//        public Object Links { get; set; } // currently not supported
//        public Object Callbacks { get; set; } // currently not supported
        public bool Deprecated { get; set; }
        
    }
}