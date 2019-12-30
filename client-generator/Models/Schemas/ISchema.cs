using System.Collections.Generic;
using client_generator.Generators;

namespace client_generator.Models.Schemas
{
    public interface ISchema
    {

        string GetName();

        SchemaType GetSchemaType();

        IEnumerable<ISchema> GetRelatedSchemes();

        ITransformable CodeModel();

    }
}
