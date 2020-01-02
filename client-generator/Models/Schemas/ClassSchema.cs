using System.Collections.Generic;
using System.Linq;
using client_generator.Templates;

namespace client_generator.Models.Schemas
{
    public class ClassSchema : ISchema
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

        public ITemplate GetTemplate(ITemplateFactory templateFactory)
        {
            return templateFactory.CreateClassSchemaTemplate(_name,
                _properties.ToDictionary(pair => pair.Key, pair => pair.Value.GetName()), _requiredProperties);
        }

    }
}
