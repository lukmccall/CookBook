using System.Collections.Generic;
using client_generator.Models.Schemas;
using Name = System.String;
using Type = System.String;

namespace client_generator.Templates.Schemes
{
    public interface IClassSchemaTemplateFactory
    {

        ITemplate CreateClassSchemaTemplate(string name, Dictionary<string, ISchema> properties,
            IEnumerable<string> requiredProperties);

    }
}
