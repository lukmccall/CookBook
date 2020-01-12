using System.Collections.Generic;
using client_generator.Models.Generators;

namespace client_generator.Generators.FilesStrategies
{
    public interface IGeneratorFileStrategy
    {

        List<string> CreateFiles(Dictionary<string, Type> types, Dictionary<string, Function> functions);

    }
}
