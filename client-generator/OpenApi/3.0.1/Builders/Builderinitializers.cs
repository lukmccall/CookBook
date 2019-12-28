using System.Collections.Generic;
using System.Linq;
using client_generator.Deserializer;
using client_generator.Models;
using client_generator.OpenApi._3._0._1.Builders.Schema;

namespace client_generator.OpenApi._3._0._1.Builders
{
    public static class Builderinitializers
    {
        public static void SchemaMap(string key, _3._0._1.Schema schema, Dictionary<string, ISchema> created,
            Dictionary<string, ISuspendBuilder<ISchema>> inProgress)
        {
            switch (schema.Type)
            {
                case "integer":
                    created.Add(key, new SimpleSchema(FieldType.Int));
                    break;
                case "string":
                    created.Add(key, new SimpleSchema(FieldType.String));
                    break;
                case "number":
                    created.Add(key, new SimpleSchema(FieldType.Number));
                    break;
                case "array":
                {
                    var builder = new ArraySchemaBuilder(schema.Items?.GetRef() ?? $"{key}/items", created);
                    builder.Parse();
                    if (builder.CanCreate())
                    {
                        created.Add(key, builder.Create());
                    }
                    else
                    {
                        inProgress.Add(key, builder);
                    }

                    break;
                }
                case "boolean":
                    created.Add(key, new SimpleSchema(FieldType.Bool));
                    break;
                case "object":
                {
                    var builder = new ClassSchemaBuilder(key.Split('/').Last(), key, schema, created);
                    builder.Parse();
                    if (builder.CanCreate())
                    {
                        created.Add(key, builder.Create());
                    }
                    else
                    {
                        inProgress.Add(key, builder);
                    }

                    break;
                }
            }
        }
    }
}