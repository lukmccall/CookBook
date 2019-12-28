using client_generator.Models;
using client_generator.OpenApi._3._0._1.Referable;

namespace client_generator.OpenApi._3._0._1
{
    public class Parameter : ICollectable<IReferenceCollector>
    {
        public string Name { get; set; }
        public string In { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Deprecated { get; set; }
        public bool AllowEmptyValue { get; set; }
        public string Style { get; set; }
        public bool Explode { get; set; }
        public bool AllowReserved { get; set; }
        public IReferable<Schema> Schema { get; set; }

//        public Object Exmample { get; set; } // currently not supported
//        public Object Exmample { get; set; } // currently not supported
//        public List<Object> Examples { get; set; } // currently not supported 
//        public Object Content { get; set; } // currently not supported
        public void Accept(string path, IReferenceCollector collector)
        {
            if (Schema != null)
            {
                collector.Visit($"{path}/schema", Schema);
                Schema.GetObject()?.Accept($"{path}/schema", collector);
            }
        }
    }
}