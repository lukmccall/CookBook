using System.Collections.Generic;
using System.Linq;
using client_generator.Deserializer.Helpers.Builders;
using client_generator.Models;
using client_generator.Models.Schemas;

namespace client_generator.OpenApi._3._0._1.Builders.Schema
{
    public class ClassSchemaBuilder : ISuspendBuilder<ISchema>
    {

        private readonly string _name;

        private readonly string _path;

        private readonly Dictionary<string, ISchema> _properties = new Dictionary<string, ISchema>();

        private readonly Dictionary<string, ISchema> _schemata;

        private List<KeyValuePair<string, string>> _propertiesToParse;

        private readonly IEnumerable<string> _requiredProperties;

        public ClassSchemaBuilder(string name, string path, IEnumerable<string> requiredProperties, _1.Schema model,
            Dictionary<string, ISchema> schemata)
        {
            _name = name;
            _path = path;
            _schemata = schemata;
            _requiredProperties = requiredProperties ?? new List<string>();

            if (model.Properties != null)
            {
                _propertiesToParse = model.Properties
                    .Select(x => new KeyValuePair<string, string>(x.Key, x.Value.GetRef())).ToList();
            }
            else
            {
                _propertiesToParse = new List<KeyValuePair<string, string>>();
            }
        }

        public bool CanCreate()
        {
            return _propertiesToParse.Count == 0;
        }

        public ISchema Create()
        {
            return new ClassSchema(_name, _properties, _requiredProperties);
        }

        public void Parse()
        {
            var newProperiesToParse = new List<KeyValuePair<string, string>>();
            foreach (var (key, @ref) in _propertiesToParse)
            {
                ISchema schema;
                if (@ref != null && _schemata.TryGetValue(@ref, out schema))
                {
                    _properties.Add(key, schema);
                }
                else if (_schemata.TryGetValue($"{_path}/properties/{key}", out schema))
                {
                    _properties.Add(key, schema);
                }
                else
                {
                    newProperiesToParse.Add(new KeyValuePair<string, string>(key, @ref));
                }
            }

            _propertiesToParse = newProperiesToParse;
        }

    }
}
