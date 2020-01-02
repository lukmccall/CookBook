using System.Collections.Generic;
using client_generator.Models.Schemas;

namespace client_generator.Models.Generators
{
    public class Function
    {

        public string Code { get; set; }

        public IEnumerable<ISchema> RelatedSchemas { get; set; }

    }
}
