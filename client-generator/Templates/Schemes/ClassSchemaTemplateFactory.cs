using System.Collections.Generic;

namespace client_generator.Templates.Schemes
{
    public class ClassSchemaTemplateFactory : IClassSchemaTemplateFactory
    {

        public ITemplate CreateClassSchemaTemplate(string name, Dictionary<string, string> properties, IEnumerable<string> requiredProperties)
        {
            return new ClassSchemaTemplate(name, properties, requiredProperties);
        }

    }
}
