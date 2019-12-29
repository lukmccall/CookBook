using System.Collections.Generic;
using client_generator.Generators;

namespace client_generator.Templates.Schemes
{
    public partial class ClassSchemaTemplate : ITransformable
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
