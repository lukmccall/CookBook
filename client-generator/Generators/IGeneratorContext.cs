using System.Collections.Generic;
using client_generator.Models.Schemas;
using client_generator.Templates;

namespace client_generator.Generators
{
    public interface IGeneratorContext
    {

        bool TypeExists(string typeName);

        void AddType(string typeName, string code, IEnumerable<ISchema> relatedSchemas);

        void AddFunction(string name, string body, IEnumerable<ISchema> relatedSchemas);

        ITemplateFactory GetTemplateFactory();

    }
}
