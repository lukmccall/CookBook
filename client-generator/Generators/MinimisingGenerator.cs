using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using client_generator.Models.Generators;

namespace client_generator.Generators
{
    internal class MinimisingGenerator : Generator
    {

        public MinimisingGenerator(IGeneratorContext context) : base(context)
        {
        }

        protected override void CreateFiles(Dictionary<string, Type> types, Dictionary<string, Function> functions)
        {
            var generatedFiles = FileStrategies[GeneratorSettings.SchemePlace].CreateFiles(types, functions);

            foreach (var filePath in generatedFiles)
            {
                File.WriteAllText(filePath, Regex.Replace(File.ReadAllText(filePath), @"\s+", " "));
            }
        }

    }
}
