using System.Collections.Generic;
using System.IO;
using System.Linq;
using client_generator.Deserializer;
using client_generator.Models;
using client_generator.OpenApi._3._0._1.Converters;
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

            var set = new Dictionary<string, ISchema>();
            var inProggres = new Dictionary<string, ClassSchemaBuilder>();
            var schemats = collector.GetObjectOfType<Schema>();

            foreach (var (key, schema) in schemats)
            {
                switch (schema.Type)
                {
                    case "integer":
                        set.Add(key, new SimpleSchema(FieldType.Int));
                        break;
                    case "string":
                        set.Add(key, new SimpleSchema(FieldType.String));
                        break;
                    case "number":
                        set.Add(key, new SimpleSchema(FieldType.Number));
                        break;
                    case "array":
                        set.Add(key, new SimpleSchema(FieldType.Array));
                        break;
                    case "boolean":
                        set.Add(key, new SimpleSchema(FieldType.Bool));
                        break;

                    case "object":
                    {
                        var builder = new ClassSchemaBuilder(key.Split('/').Last(), key, schema, set);
                        builder.ParseProperties();
                        if (builder.CanCreate())
                        {
                            set.Add(key, builder.Create());
                        }
                        else
                        {
                            inProggres.Add(key, builder);
                        }
                    }
                        break;
                }
            }

            while (inProggres.Count != 0)
            {
                foreach (var (key, builder) in inProggres)
                {
                    if (builder.CanCreate())
                    {
                        set.Add(key, builder.Create());
                        inProggres.Remove(key);
                    }
                    else
                    {
                        builder.ParseProperties();
                    }
                }
            }

            throw new System.NotImplementedException();
        }
    }
}