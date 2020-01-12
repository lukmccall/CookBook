using System.Collections.Generic;
using client_generator.Models.Schemas;

namespace client_generator.Templates.Schemes
{
    public class ClassSchemaTemplateFactory : IClassSchemaTemplateFactory
    {

        public ITemplate CreateClassSchemaTemplate(string name, Dictionary<string, ISchema> properties,
            IEnumerable<string> requiredProperties)
        {
            return new ClassSchemaTemplate(name, properties, requiredProperties);
        }

    }
}
