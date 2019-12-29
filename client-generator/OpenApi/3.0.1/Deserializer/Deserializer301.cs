using System;
using System.Collections.Generic;
using client_generator.Deserializer;
using client_generator.Deserializer.Helpers.Builders;
using client_generator.Deserializer.Helpers.JsonConverters;
using client_generator.Generators;
using client_generator.Models;
using client_generator.OpenApi._3._0._1.Builders;
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
            var openApiModel = new OpenApiModel();

            var collector = new ReferableCollector();
            versionedModel.Accept("#", collector);
            collector.Validate();

            var buildManager = new SuspendBuildsManager<Schema, ISchema>(collector.GetObjectOfType<Schema>(),
                BuilderInitializers.SchemaMap);
            buildManager.Build();
            var schematas = buildManager.GetResult();

            var codeGenerator = new TsGenerator(new GeneratorSetting
            {
                SchemePlace = SchemeGeneratePlace.AllSeparated
            });
            foreach (var (key, schema) in schematas)
            {
                codeGenerator.GenerateSchema(schema);
            }

            throw new NotImplementedException();
        }

    }
}
