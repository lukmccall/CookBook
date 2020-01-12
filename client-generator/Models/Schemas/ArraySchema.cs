using System.Collections.Generic;
using client_generator.Templates;

namespace client_generator.Models.Schemas
{
    public class ArraySchema : ISchema
    {

        private readonly ISchema _schema;

        public ArraySchema(ISchema schema)
        {
            _schema = schema;
        }

        public string GetName()
        {
            return $"Array<{_schema.GetName()}>";
        }

        public SchemaType GetSchemaType()
        {
            return SchemaType.Array;
        }

        public IEnumerable<ISchema> GetRelatedSchemes()
        {
            return new[]
            {
                _schema
            };
        }

        public ITemplate GetTemplate(ITemplateFactory templateFactory)
        {
            return null;
        }

    }
}
