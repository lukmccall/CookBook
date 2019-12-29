using System.Collections.Generic;
using client_generator.Generators;
using client_generator.OpenApi._3._0._1;

namespace client_generator.Models
{
    public interface ISchema
    {

        string GetName();

        SchemaType GetSchemaType();

        IEnumerable<ISchema> GetRelatedSchemes();

        ITransformable CodeModel();

    }
}
