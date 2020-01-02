using System.Collections.Generic;
using Name = System.String;
using Type = System.String;

namespace client_generator.Templates.Schemes
{    
    public interface IClassSchemaTemplateFactory
    {

        ITemplate CreateClassSchemaTemplate(Name name, Dictionary<Name, Type> properties, IEnumerable<Name> requiredProperties);

    }
}
