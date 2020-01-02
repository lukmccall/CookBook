using System.Collections.Generic;
using client_generator.Models.Schemas;

namespace client_generator.Generators
{
    public interface IGeneratorContext
    {

        void AddType(string typeName, string code, IEnumerable<ISchema> relatedSchemas);

        void AddFunction(string name, string body);
        
        void CreateNewEndpointContext();

        IEndpointContext GetCurrentEndpointContext();

    }
}
