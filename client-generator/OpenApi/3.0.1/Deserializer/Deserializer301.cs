using System;
using System.Collections.Generic;
using System.Linq;
using client_generator.Deserializer;
using client_generator.Deserializer.Helpers.Builders;
using client_generator.Deserializer.Helpers.JsonConverters;
using client_generator.Models;
using client_generator.Models.Endpoints;
using client_generator.Models.Parameters;
using client_generator.Models.Requests;
using client_generator.Models.Responses;
using client_generator.Models.Schemas;
using client_generator.OpenApi._3._0._1.Builders;
using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;

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
            var openApiBuilder = new OpenApiModel.OpenApiModelBuilder();

            var collector = new ReferableCollector();
            versionedModel.Accept("#", collector);
            collector.Validate();

            if (!collector.Validate())
            {
                throw new JsonException("Not all references was satisfied.");
            }

            MapSchemes(openApiBuilder, collector.GetObjectOfType<Schema>());
            MapHeaders(openApiBuilder, collector.GetObjectOfType<Header>());
            MapRequestBodies(openApiBuilder, collector.GetObjectOfType<Request>());
            MapParameters(openApiBuilder, collector.GetObjectOfType<Parameter>());
            MapResponses(openApiBuilder, collector.GetObjectOfType<Response>());
            MapEndpoints(openApiBuilder, versionedModel.Paths);

            return openApiBuilder.Create();
        }

        private void MapSchemes(OpenApiModel.OpenApiModelBuilder openApiBuilder,
            Dictionary<string, Schema> versionedSchemes)
        {
            var buildManager =
                new SuspendBuildsManager<Schema, ISchema>(versionedSchemes, BuilderInitializers.SchemaMap);

            if (!buildManager.Build())
            {
                throw new ArgumentException("Couldn't create schemes. Pleas validate them earlier.");
            }

            openApiBuilder.AttachScheme(buildManager.GetResult());
        }

        private void MapHeaders(OpenApiModel.OpenApiModelBuilder openApiModelBuilder,
            Dictionary<string, Header> versionedHeaders)
        {
            foreach (var (key, header) in versionedHeaders)
            {
                var schemaPath = header.Schema.GetRef() ?? $"{key}/schema";
                var schema = openApiModelBuilder.GetSchemaForPath(schemaPath);

                if (schema == null)
                {
                    throw new ArgumentException(
                        $"Couldn't create headers - missing schema {schemaPath}. Pleas validate them earlier.");
                }

                var name = key.Split("/").Last();
                var isRequired = header.Required ?? false;
                var isDeprecated = header.Deprecated ?? false;
                var allowEmptyValue = header.AllowEmptyValue ?? false;

                openApiModelBuilder.AttachHeader(key,
                    new Models.Headers.Header(name, schema, isRequired, isDeprecated, allowEmptyValue));
            }
        }

        private void MapRequestBodies(OpenApiModel.OpenApiModelBuilder openApiModelBuilder,
            Dictionary<string, Request> versionedBodies)
        {
            foreach (var (path, requestBody) in versionedBodies)
            {
                var isRequired = requestBody.Required ?? false;
                var schemas = new Dictionary<string, ISchema>();

                if (requestBody.Content != null)
                {
                    foreach (var (type, mediaType) in requestBody.Content)
                    {
                        var schemaPath = mediaType.Schema.GetRef() ?? $"{path}/content/{type}/schema";
                        var schema = openApiModelBuilder.GetSchemaForPath(schemaPath);

                        if (schema == null)
                        {
                            throw new ArgumentException(
                                $"Couldn't create request body - missing schema {schemaPath}. Pleas validate them earlier.");
                        }

                        schemas.Add(type, schema);
                    }
                }

                openApiModelBuilder.AttachRequestBody(path, new RequestBody(schemas, isRequired));
            }
        }

        private void MapResponses(OpenApiModel.OpenApiModelBuilder openApiModelBuilder,
            Dictionary<string, Response> versionedResponses)
        {
            foreach (var (path, response) in versionedResponses)
            {
                var schemas = new Dictionary<string, ISchema>();

                if (response.Content != null)
                {
                    foreach (var (type, mediaType) in response.Content)
                    {
                        var schemaPath = mediaType.Schema.GetRef() ?? $"{path}/content/{type}/schema";
                        var schema = openApiModelBuilder.GetSchemaForPath(schemaPath);

                        if (schema == null)
                        {
                            throw new ArgumentException(
                                $"Couldn't create response - missing schema {schemaPath}. Pleas validate them earlier.");
                        }

                        schemas.Add(type, schema);
                    }
                }

                openApiModelBuilder.AttachResponse(path, new Models.Responses.Response(schemas));
            }
        }

        private void MapParameters(OpenApiModel.OpenApiModelBuilder openApiModelBuilder,
            Dictionary<string, Parameter> versionedParameters)
        {
            foreach (var (key, parameter) in versionedParameters)
            {
                var schemaPath = parameter.Schema.GetRef() ?? $"{key}/schema";
                var schema = openApiModelBuilder.GetSchemaForPath(schemaPath);

                if (schema == null)
                {
                    throw new ArgumentException(
                        $"Couldn't create parameter - missing schema {schemaPath}. Pleas validate them earlier.");
                }

                var name = parameter.Name ?? throw new ArgumentException("Parameter has to have the name.");
                var isRequired = parameter.Required ?? false;
                var isDeprecated = parameter.Deprecated ?? false;
                var allowEmptyValue = parameter.AllowEmptyValue ?? false;
                var parameterTypeString = parameter.In ?? "";

                var map = new Dictionary<string, ParameterType>
                {
                    {"query", ParameterType.Query},
                    {"header", ParameterType.Header},
                    {"path", ParameterType.Path},
                };

                if (!map.ContainsKey(parameterTypeString))
                {
                    throw new ArgumentException($"Invalid `in` value - {parameterTypeString}");
                }

                openApiModelBuilder.AttachParameter(key,
                    new Models.Parameters.Parameter(name, map[parameterTypeString], schema, isRequired, isDeprecated,
                        allowEmptyValue));
            }
        }

        private void MapEndpoints(OpenApiModel.OpenApiModelBuilder openApiModelBuilder,
            Dictionary<string, PathItem> pathItems)
        {
            foreach (var (url, pathItem) in pathItems)
            {
                var path = $"#/paths/{url}";
                var parameters = new HashSet<IParameter>();

                if (pathItem.Parameters != null)
                {
                    foreach (var versionedParameter in pathItem.Parameters)
                    {
                        var parameterPath = versionedParameter.GetRef() ??
                                            $"{path}/parameters/{versionedParameter.GetObject().Name}";
                        var parameter = openApiModelBuilder.GetParameterForPath(parameterPath);
                        if (parameter == null)
                        {
                            throw new ArgumentException($"Missing parameter object - {parameterPath}");
                        }

                        parameters.Add(parameter);
                    }
                }

                var operationMap = GetOperationMap(pathItem);
                foreach (var (type, operation) in operationMap)
                {
                    var endpointParameters = new HashSet<IParameter>(parameters);

                    if (operation.Parameters != null)
                    {
                        foreach (var operationParameter in operation.Parameters)
                        {
                            var parameterPath = operationParameter.GetRef() ??
                                                $"{path}/{type.ToString().ToLower()}/parameters/{operationParameter.GetObject().Name}";
                            var parameter = openApiModelBuilder.GetParameterForPath(parameterPath);
                            if (parameter == null)
                            {
                                throw new ArgumentException($"Missing parameter object - {parameterPath}");
                            }

                            endpointParameters.Add(parameter);
                        }
                    }

                    var endpointResponses = new List<IHttpResponse>();
                    foreach (var (status, @ref) in operation.Responses)
                    {
                        var responsePath =
                            @ref.GetRef() ?? $"{path}/{type.ToString().ToLower()}/responses/{status}";
                        var response = openApiModelBuilder.GetResponseForPath(responsePath);
                        endpointResponses.Add(new HttpResponse(int.Parse(status),
                            response)); // todo: check if parse was successful 
                    }

                    IRequestBody requestBody = null;
                    if (operation.RequestBody != null)
                    {
                        var requestBodyPath = operation.RequestBody?.GetRef() ??
                                              $"{path}/{type.ToString().ToLower()}/requestBody";
                        requestBody = openApiModelBuilder.GetRequestBodyForPath(requestBodyPath);
                    }

                    var operationId = operation.OperationId ??
                                      throw new ArgumentException($"Missing operationId - {path}/{type}");
                    openApiModelBuilder.AttachEndpoint(new Endpoint(operationId, url,
                        type,
                        endpointParameters, requestBody, endpointResponses));
                }
            }
        }

        private static Dictionary<EndpointType, Operation> GetOperationMap(PathItem pathItem)
        {
            var operationMap = new Dictionary<EndpointType, Operation>();
            if (pathItem.Get != null)
            {
                operationMap.Add(EndpointType.Get, pathItem.Get);
            }

            if (pathItem.Put != null)
            {
                operationMap.Add(EndpointType.Put, pathItem.Put);
            }

            if (pathItem.Post != null)
            {
                operationMap.Add(EndpointType.Post, pathItem.Post);
            }

            if (pathItem.Delete != null)
            {
                operationMap.Add(EndpointType.Delete, pathItem.Delete);
            }

            if (pathItem.Options != null)
            {
                operationMap.Add(EndpointType.Options, pathItem.Options);
            }

            if (pathItem.Head != null)
            {
                operationMap.Add(EndpointType.Head, pathItem.Head);
            }

            if (pathItem.Patch != null)
            {
                operationMap.Add(EndpointType.Patch, pathItem.Patch);
            }

            if (pathItem.Trace != null)
            {
                operationMap.Add(EndpointType.Trace, pathItem.Trace);
            }

            return operationMap;
        }

    }
}
