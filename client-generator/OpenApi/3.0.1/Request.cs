using System.Collections.Generic;

namespace client_generator.OpenApi._3._0._1
{
    public class Request
    {
        public string Description { get; set; }
        public Dictionary<string, MediaType> Content { get; set; }
        public bool Required { get; set; }
    }
}