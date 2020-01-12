using System.Collections.Generic;
using System.Linq;
using client_generator.Models.Generators;
using client_generator.Models.Schemas;
using SchemaType = client_generator.Models.SchemaType;
using Type = client_generator.Models.Generators.Type;

namespace client_generator.Generators.FilesStrategies
{
    class AllSeparatedFileStrategy : ContextDependedFileStrategy
    {

        public AllSeparatedFileStrategy(IGeneratorContext context, GeneratorSettings settings) : base(context, settings)
        {
        }

        public override List<string> CreateFiles(Dictionary<string, Type> types, Dictionary<string, Function> functions)
        {
            var createdFile = new List<string>();
            foreach (var (name, type) in types)
            {
                var file = new TsFile(name);

                var imports = type
                    .RelatedSchemas
                    .Distinct()
                    .Select(x => GetImportsFormRelatedTypes(new List<ISchema> {x}))
                    .SelectMany(x => x)
                    .Select(x =>
                        "import { " + x + $" }} from \"./{x}\";")
                    .ToList();

                if (imports.Any())
                {
                    file.Write(imports);
                    file.Write("");
                }

                file.Write(type.Code);

                file.Write("");

                file.Write("export { " + name + " };");

                createdFile.Add(file.ToSystemFile());
            }

            var clientFile = new TsFile(Settings.ClientFileName);
            var clientImports = functions.Select(x => x.Value.RelatedSchemas)
                .SelectMany(x => x)
                .Distinct().Select(x => "import { " + x.GetName() + " } from \"./" + x.GetName() + "\";");


            var template = Context.GetTemplateFactory()
                .CreateClientTemplate(Settings.ServerUrl, functions.Select(x => x.Value.Code), clientImports);

            clientFile.Write(template.TransformText());

            createdFile.Add(clientFile.ToSystemFile());

            return createdFile;
        }

        private IEnumerable<string> GetImportsFormRelatedTypes(IEnumerable<ISchema> schemas)
        {
            var imports = new List<string>();
            foreach (var schema in schemas)
            {
                if (schema.GetSchemaType() == SchemaType.Object)
                {
                    imports.Add(schema.GetName());
                }
                else if (schema.GetSchemaType() == SchemaType.Array)
                {
                    imports.AddRange(GetImportsFormRelatedTypes(schema.GetRelatedSchemes()));
                }
            }

            return imports;
        }

    }
}
