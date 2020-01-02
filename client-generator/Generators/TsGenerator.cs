using System.Collections.Generic;
using client_generator.Models.Schemas;

namespace client_generator.Generators
{
    public class TsGenerator
    {

        private static readonly string TypeFile = "types";

        private static readonly string MainFile = "main";

        private readonly Dictionary<string, TsFile> _generatedCode = new Dictionary<string, TsFile>();
        
        private readonly GeneratorSettings _generatorSettings;

        public TsGenerator()
        {
            _generatorSettings = new GeneratorSettings
            {
                SchemePlace = SchemeGeneratePlace.SeparatedFile
            };
        }

        public TsGenerator(GeneratorSettings generatorSettings)
        {
            _generatorSettings = generatorSettings;
        }

        public void GenerateType(string name, string code, IEnumerable<ISchema> relatedTypes)
        {
            switch (_generatorSettings.SchemePlace)
            {
                case SchemeGeneratePlace.SeparatedFile:
                case SchemeGeneratePlace.WithCode:
                {
                    var file = GetFile(TypeFile);
                    file.Write(code);
                    file.Export(name);
                }
                    break;
            }
        }

        public void AddFunction(string name, string body)
        {
            var mainFile = GetFile(MainFile);
            mainFile.Write(body);
        }

        private TsFile GetFile(string name)
        {
            if (!_generatedCode.ContainsKey(name))
            {
                _generatedCode.Add(name, new TsFile());
            }

            return _generatedCode[name];
        }

    }
}
