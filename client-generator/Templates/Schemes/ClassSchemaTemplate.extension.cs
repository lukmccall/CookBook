using System.Collections.Generic;
using client_generator.Models.Schemas;

namespace client_generator.Templates.Schemes
{
    public partial class ClassSchemaTemplate : ITemplate
    {

        private readonly Dictionary<string, ISchema> _properties;

        private readonly IEnumerable<string> _requiredProperties;

        private readonly string _name;

        public ClassSchemaTemplate(string name, Dictionary<string, ISchema> properties, IEnumerable<string> requiredProperties)
        {
            _name = name;
            _properties = properties;
            _requiredProperties = requiredProperties;
        }

    }
}
