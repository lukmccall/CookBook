using System.Collections.Generic;
using client_generator.Models.Schemas;
using client_generator.Templates;

namespace client_generator.Models
{
    internal class SimpleSchema : ISchema
    {

        private static readonly Dictionary<SchemaType, string> TypeToName = new Dictionary<SchemaType, string>
        {
            {SchemaType.Int, "number"},
            {SchemaType.Number, "number"},
            {SchemaType.Bool, "boolean"},
            {SchemaType.String, "string"}
        };

        private readonly SchemaType _type;

        public SimpleSchema(SchemaType type)
        {
            _type = type;
        }

        public string GetName()
        {
            return TypeToName.ContainsKey(_type) ? TypeToName[_type] : "any";
        }

        public SchemaType GetSchemaType()
        {
            return _type;
        }

        public IEnumerable<ISchema> GetRelatedSchemes()
        {
            return new List<ISchema>();
        }

        public ITemplate GetTemplate(ITemplateFactory templateFactory)
        {
            return null;
        }

    }
}
