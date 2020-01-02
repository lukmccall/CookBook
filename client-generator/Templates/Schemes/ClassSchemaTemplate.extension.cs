using System.Collections.Generic;

namespace client_generator.Templates.Schemes
{
    public partial class ClassSchemaTemplate : ITemplate
    {

        private readonly Dictionary<string, string> _properties;

        private readonly IEnumerable<string> _requiredProperties;

        private readonly string _name;

        public ClassSchemaTemplate(string name, Dictionary<string, string> properties, IEnumerable<string> requiredProperties)
        {
            _name = name;
            _properties = properties;
            _requiredProperties = requiredProperties;
        }

    }
}
