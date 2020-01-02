using System.Collections.Generic;
using client_generator.Generators;
using client_generator.Templates;

namespace client_generator.Models.Schemas
{
    public interface ISchema
    {

        string GetName();

        SchemaType GetSchemaType();

        IEnumerable<ISchema> GetRelatedSchemes();

        ITemplate GetTemplate(ITemplateFactory templateFactory);

    }
}
