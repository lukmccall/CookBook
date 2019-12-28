using System.Collections.Generic;
using System.IO;
using System.Linq;
using client_generator.Deserializer;
using client_generator.Models;
using client_generator.OpenApi._3._0._1.Builders;
using client_generator.OpenApi._3._0._1.Builders.Schema;
using client_generator.OpenApi._3._0._1.JsonConverters;
using client_generator.OpenApi._3._0._1.Referable;
using Newtonsoft.Json;

namespace client_generator.OpenApi._3._0._1.Deserializer
{
    public class Deserializer301 : Deserializer<OpenApiFile>
    {
        public Deserializer301(JsonSerializerSettings settings) : base(settings)
        {
        }

        protected override IList<JsonConverter> GetConverters()
        {
            var converters = new List<JsonConverter>
            {
                new ReferableConverter<Parameter>(),
                new ReferableConverter<Schema>(),
                new ReferableConverter<Request>(),
                new ReferableConverter<Response>(),
                new ReferableConverter<Header>()
            };
            converters.AddRange(base.GetConverters());
            return converters;
        }

        protected override OpenApiModel Convert(OpenApiFile versionedModel)
        {
            OpenApiModel openApiModel = new OpenApiModel();

            ReferableCollector collector = new ReferableCollector();
            versionedModel.Accept("#", collector);
            collector.Validate();

            var buildManager = new SuspendBuildsManager<Schema, ISchema>(collector.GetObjectOfType<Schema>(),
                (key, schema, created, inProgress) =>
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
                });
            buildManager.Build();
            var schematas = buildManager.GetResult();
            throw new System.NotImplementedException();
        }
    }
}