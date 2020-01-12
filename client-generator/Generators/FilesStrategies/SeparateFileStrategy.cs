using System.Collections.Generic;
using System.Linq;
using client_generator.Extensions;
using client_generator.Models.Generators;
using client_generator.Models.Schemas;

namespace client_generator.Generators.FilesStrategies
{
    internal class SeparateFileStrategy : ContextDependedFileStrategy
    {

        public SeparateFileStrategy(IGeneratorContext context, GeneratorSettings settings) : base(context, settings)
        {
        }

        public override List<string> CreateFiles(Dictionary<string, Type> types, Dictionary<string, Function> functions)
        {
            var typeFile = new TsFile(Settings.TypesFileName);

            var relatedSchemas = types.Select(x => x.Value.RelatedSchemas)
                .SelectMany(x => x)
                .Distinct();

            var imports = GetImportsString(typeFile, relatedSchemas).ToList();
            if (imports.Any())
            {
                typeFile.Write(imports);
                typeFile.Write("");
            }

            foreach (var (_, type) in types)
            {
                typeFile.Write(type.Code);
                typeFile.Write("");
            }

            var exports = types.Select(x => x.Key).StrJoin(", ");

            typeFile.Write("export { " + exports + " };");

            var mainFile = new TsFile(Settings.ClientFileName);

            relatedSchemas = functions.Select(x => x.Value.RelatedSchemas)
                .SelectMany(x => x)
                .Distinct();

            imports = GetImportsString(mainFile, relatedSchemas).ToList();

            var template = Context.GetTemplateFactory()
                .CreateClientTemplate(Settings.ServerUrl, functions.Select(x => x.Value.Code), imports);

            mainFile.Write(template.TransformText());

            if (FileFilter != null)
            {
                FileFilter.Invoke(typeFile);
                FileFilter.Invoke(mainFile);
            }

            return new List<string>
            {
                typeFile.ToSystemFile(),
                mainFile.ToSystemFile()
            };
        }

        private IEnumerable<string> GetImportsString(TsFile fromFile, IEnumerable<ISchema> schemas)
        {
            if (fromFile.FileName == Settings.TypesFileName)
            {
                return new List<string>();
            }

            return new List<string>
            {
                "import { " + schemas.Select(x => x.GetName()).StrJoin(", ") + " } from \"./types\";"
            };
        }

    }
}
