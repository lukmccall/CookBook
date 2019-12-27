using System.Collections.Generic;
using client_generator.Deserializer;
using client_generator.Models;
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

            throw new System.NotImplementedException();
        }
    }
}