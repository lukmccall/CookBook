using System.Collections.Generic;
using client_generator.Models.Schemas;

namespace client_generator.Templates.Schemes
{
    public partial class ClassSchemaTemplate : ITemplate
    {

        private readonly string _name;

        private readonly Dictionary<string, ISchema> _properties;

        private readonly IEnumerable<string> _requiredProperties;

        public ClassSchemaTemplate(string name, Dictionary<string, ISchema> properties,
            IEnumerable<string> requiredProperties)
        {
            _name = name;
            _properties = properties;
            _requiredProperties = requiredProperties;
        }

    }
}
