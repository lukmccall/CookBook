using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using client_generator.Models.Endpoints;
using client_generator.Models.Parameters;
using client_generator.Models.Requests;
using client_generator.Models.Responses;
using client_generator.Models.Schemas;
using client_generator_tests.Helpers;
using Xunit;
using Parameter = client_generator.Models.Parameters.Parameter;
using Response = client_generator.Models.Responses.Response;

namespace client_generator_tests.Generators
{
    public class GeneratorTest
    {

        private static readonly string Class = "Class";

        private static readonly string OperationId = "operation";

        private static readonly string Path = "path";

        private static readonly string ApplicationJson = "application/json";

        private static readonly string InnerClass = "innerClass";

        private static readonly string Request = "request";

        private static readonly string Response = "response";

        private static readonly string StringKey = "string";

        private static readonly string NumberKey = "number";

        private static (Endpoint endpoint, IEnumerable<ISchema> schemas) ReturnsRealEndpoint()
        {
            var numberSchema = new SimpleSchema(SchemaType.Number);
            var stringSchema = new SimpleSchema(SchemaType.String);

            var responseSchema = new ClassSchema(
                Response,
                new Dictionary<string, ISchema>
                {
                    {StringKey, stringSchema}
                },
                new List<string>()
            );

            var requestSchema = new ClassSchema(
                Request,
                new Dictionary<string, ISchema>
                {
                    {NumberKey, numberSchema},
                    {StringKey, stringSchema},
                }, new List<string>()
            );

            var endpoint = new Endpoint(
                OperationId, Path,
                EndpointType.Get,
                new HashSet<IParameter>
                {
                    new Parameter(
                        "parameter",
                        ParameterType.Header,
                        stringSchema,
                        false,
                        false,
                        false
                    )
                },
                new RequestBody(
                    new Dictionary<string, ISchema>
                    {
                        {ApplicationJson, requestSchema},
                    },
                    true),
                new[]
                {
                    new HttpResponse(
                        200,
                        new Response(new Dictionary<string, ISchema>
                        {
                            {ApplicationJson, responseSchema}
                        })),
                });

            return (endpoint, new List<ISchema>
            {
                numberSchema, stringSchema, requestSchema, responseSchema
            });
        }

        [Fact]
        public void ParseSchemaObject()
        {
            // Arrange
            var schemas = new List<ISchema>
            {
                new SimpleSchema(SchemaType.Number),
                new SimpleSchema(SchemaType.String),
                new ClassSchema(Class, new Dictionary<string, ISchema>(), new List<string>())
            };
            var generator = new GeneratorAccessor(new TemplateFactoryMock());

            // Act
            generator.AccessParseSchemas(schemas);
            var types = generator.AccessGeneratorContext.GetTypesToGenerate();

            // Assert
            Assert.Single(types);
            Assert.Equal(Class, types.Keys.First());
            Assert.Equal(Class, types.Values.First().Code);
        }

        [Fact]
        public void ParseSchemaRelatedObjects()
        {
            // Arrange
            var innerClassSchema = new ClassSchema(InnerClass, new Dictionary<string, ISchema>(), new List<string>());
            var schemas = new List<ISchema>
            {
                new ClassSchema(Class, new Dictionary<string, ISchema>
                    {
                        {InnerClass, innerClassSchema}
                    },
                    new List<string> {InnerClass})
            };
            var generator = new GeneratorAccessor(new TemplateFactoryMock());

            // Act
            generator.AccessParseSchemas(schemas);
            var types = generator.AccessGeneratorContext.GetTypesToGenerate();

            // Assert
            Assert.Equal(2, types.Count);
            Assert.True(types.ContainsKey(InnerClass), "Should contains required types.");
            Assert.True(types.ContainsKey(Class), "Should contains required types.");
        }

        [Fact]
        public void ParseEndpoints()
        {
            // Arrange
            var endpoint = new Endpoint(OperationId, Path, EndpointType.Get, new HashSet<IParameter>(), null,
                new List<IHttpResponse>
                {
                    new HttpResponse(200, new Response(new Dictionary<string, ISchema>
                    {
                        {ApplicationJson, new SimpleSchema(SchemaType.String)}
                    }))
                });
            var generator = new GeneratorAccessor(new TemplateFactoryMock());

            // Act
            generator.AccessParseEndpoints(new List<IEndpoint>
                {
                    endpoint
                }
            );
            var functions = generator.AccessGeneratorContext.GetFunctionsToGenerate();

            // Assert
            Assert.Single(functions);
            Assert.Equal(OperationId, functions.Keys.First());
            Assert.Equal(Path, functions.Values.First().Code);
        }

        [Fact]
        public void ParseRealEndpoint()
        {
            // Arrange
            var (endpoint, schemas) = ReturnsRealEndpoint();
            var generator = new GeneratorAccessor(new TemplateFactoryMock());

            // Act
            generator.AccessParseSchemas(schemas);
            generator.AccessParseEndpoints(new[]
            {
                endpoint
            });
            var parseSchemas = generator.AccessGeneratorContext.GetTypesToGenerate();
            var parseFunctions = generator.AccessGeneratorContext.GetFunctionsToGenerate();

            // Assert
            Assert.Equal(2, parseSchemas.Count);
            foreach (var key in new[] {Request, Response})
            {
                Assert.Contains(key, parseSchemas.Keys);
            }

            var request = parseSchemas[Request];
            Assert.True(request.RelatedSchemas.Any(x => x.GetSchemaType() == SchemaType.Number),
                "Should contains number schema.");
            Assert.True(request.RelatedSchemas.Any(x => x.GetSchemaType() == SchemaType.String),
                "Should contains String schema.");

            Assert.Single(parseFunctions);
            Assert.Equal(OperationId, parseFunctions.Keys.First());

            var function = parseFunctions.Values.First();
            Assert.Equal(Path, function.Code);
            foreach (var key in new[] {Request, Response})
            {
                Assert.Contains(key, function.RelatedSchemas.Select(x => x.GetName()));
            }
        }

        [Fact]
        public void GenerateRealEndpoint()
        {
            // Arrange
            var (endpoint, schemas) = ReturnsRealEndpoint();
            var generator = new GeneratorAccessor(new TemplateFactoryMock());

            // Act
            generator.AccessParseSchemas(schemas);
            generator.AccessParseEndpoints(new[]
            {
                endpoint
            });
            var parseSchemas = generator.AccessGeneratorContext.GetTypesToGenerate();
            var parseFunctions = generator.AccessGeneratorContext.GetFunctionsToGenerate();
            var files = generator.AccessCreateFiles(parseSchemas, parseFunctions);

            // Assert
            Assert.Single(files);
            var content = File.ReadAllText(files.First());
            var correctFile = "request" + Environment.NewLine + Environment.NewLine +
                              "response" + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                              "export class Client {" + Environment.NewLine +
                              "    baseUrl = \"http://localhost\";" + Environment.NewLine + Environment.NewLine +
                              "    path" + Environment.NewLine + Environment.NewLine +
                              "}" + Environment.NewLine + Environment.NewLine +
                              "export { request, response };" + Environment.NewLine;

            Assert.Equal(correctFile, content);
        }

    }
}
