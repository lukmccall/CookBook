using System.Collections.Generic;
using System.Linq;
using client_generator.Generators;
using client_generator.Templates.Schemes;

namespace client_generator.Models.Schemas
{
    public class ClassSchema : ISchema
    {

        private readonly string _name;

        private readonly Dictionary<string, ISchema> _properties;

        public ClassSchema(string name, Dictionary<string, ISchema> properties)
        {
            _name = name;
            _properties = properties;
        }

        public string GetName()
        {
            return _name;
        }

        public SchemaType GetSchemaType()
        {
            return SchemaType.Object;
        }

        public IEnumerable<ISchema> GetRelatedSchemes()
        {
            return _properties.Select(x => x.Value).ToList();
        }

        public ITransformable CodeModel()
        {
            var props = new Dictionary<string, string>();
            foreach (var (key, value) in _properties)
            {
                props.Add(key, value.GetName());
            }

            return new ClassSchemaTemplate(_name, props);
        }

    }
}
