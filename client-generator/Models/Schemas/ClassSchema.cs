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

        private readonly IEnumerable<string> _requiredProperties;

        public ClassSchema(string name, Dictionary<string, ISchema> properties, IEnumerable<string> requiredProperties)
        {
            _name = name;
            _properties = properties;
            _requiredProperties = requiredProperties;
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
                    _properties, _requiredProperties);
            }

            var code = currentTemplate.TransformText();
            generator.AddType(GetName(), code, _properties?.Values);
            _needsToBeGenerated = false;
        }

    }
}
