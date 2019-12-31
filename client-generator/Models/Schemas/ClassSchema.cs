using System.Collections.Generic;
using System.Linq;
using client_generator.Generators;
using client_generator.Templates.Schemes;

namespace client_generator.Models.Schemas
{
    public class ClassSchema : TemplateHolder, ISchema
    {

        private readonly string _name;

        private bool _needsToBeGenerated = true;

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

        public override bool NeedsToBeGenerated()
        {
            return _needsToBeGenerated;
        }

        public override void Generate(IGeneratorContext generator)
        {
            if (_properties != null)
            {
                foreach (var prop in _properties.Values)
                {
                    // if needed, generates prop schema
                    if (prop.NeedsToBeGenerated())
                    {
                        prop.Generate(generator);
                    }
                }
            }

            var currentTemplate = Template;
            if (currentTemplate == null)
            {
                // todo: get this from generator context
                currentTemplate = new ClassSchemaTemplate(GetName(),
                    _properties?.ToDictionary(pair => pair.Key, pair => pair.Value.GetName()));
            }

            var code = currentTemplate.TransformText();
            generator.AddType(GetName(), code, _properties?.Values);
            _needsToBeGenerated = false;
        }

    }
}
