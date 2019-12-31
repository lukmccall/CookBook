using System.Collections.Generic;

namespace client_generator.Templates.Schemes
{
    public partial class ClassSchemaTemplate : ITemplate
    {

        private readonly Dictionary<string, string> _properties;

        private readonly string _name;

        public ClassSchemaTemplate(string name, Dictionary<string, string> properties)
        {
            _name = name;
            _properties = properties;
        }

    }
}
