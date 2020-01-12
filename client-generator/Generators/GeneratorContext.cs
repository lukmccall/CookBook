using System;
using System.Collections.Generic;
using client_generator.Models.Generators;
using client_generator.Models.Schemas;
using client_generator.Templates;
using Type = client_generator.Models.Generators.Type;

namespace client_generator.Generators
{
    public class GeneratorContext : IGeneratorContext
    {

        private readonly Dictionary<string, Type> _types = new Dictionary<string, Type>();

        private readonly Dictionary<string, Function> _functions = new Dictionary<string, Function>();

        public bool TypeExists(string typeName)
        {
            return _types.ContainsKey(typeName);
        }

        public void AddType(string typeName, string code, IEnumerable<ISchema> relatedSchemas)
        {
            if (_types.ContainsKey(typeName))
            {
                throw new ArgumentException("Type already exists.");
            }

            _types.Add(typeName, new Type
            {
                Code = code,
                RelatedSchemas = relatedSchemas
            });
        }

        public void AddFunction(string name, string body, IEnumerable<ISchema> relatedSchemas)
        {
            if (_functions.ContainsKey(name))
            {
                throw new ArgumentException("Function already exists.");
            }

            _functions.Add(name, new Function
            {
                Code = body,
                RelatedSchemas = relatedSchemas
            });
        }

        public ITemplateFactory GetTemplateFactory()
        {
            return new TemplatesFactory();
        }

        public Dictionary<string, Type> GetTypesToGenerate()
        {
            return _types;
        }

        public Dictionary<string, Function> GetFunctionsToGenerate()
        {
            return _functions;
        }

    }
}
