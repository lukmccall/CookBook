using System.Collections.Generic;
using System.Linq;
using client_generator.Extensions;
using client_generator.Models.Generators;

namespace client_generator.Generators.FilesStrategies
{
    public class SingleFileStrategy : ContextDependedFileStrategy
    {

        public SingleFileStrategy(IGeneratorContext context, GeneratorSettings settings) : base(context, settings)
        {
        }

        public override List<string> CreateFiles(Dictionary<string, Type> types, Dictionary<string, Function> functions)
        {
            var client = new TsFile(Settings.ClientFileName);


            foreach (var (_, type) in types)
            {
                client.Write(type.Code);
                client.Write("");
            }

            client.Write("");

            var mainFileTemplate = Context.GetTemplateFactory()
                .CreateClientTemplate(Settings.ServerUrl, functions.Select(x => x.Value.Code), new List<string>());

            client.Write(mainFileTemplate.TransformText());

            client.Write("");

            var exports = types.Select(x => x.Key).StrJoin(", ");
            client.Write("export { " + exports + " };");

            return new List<string>
            {
                client.ToSystemFile()
            };
        }

    }
}
