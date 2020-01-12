using System;
using System.Collections.Generic;
using client_generator.Models.Generators;
using Type = client_generator.Models.Generators.Type;

namespace client_generator.Generators.FilesStrategies
{
    public abstract class ContextDependedFileStrategy : IGeneratorFileStrategy
    {

        protected readonly IGeneratorContext Context;

        protected readonly GeneratorSettings Settings;

        protected Action<TsFile> FileFilter;

        protected ContextDependedFileStrategy(IGeneratorContext context, GeneratorSettings settings)
        {
            Context = context;
            Settings = settings;
        }

        public void SetFilter(Action<TsFile> fileFilter)
        {
            FileFilter = fileFilter;
        }

        public abstract List<string> CreateFiles(Dictionary<string, Type> types, Dictionary<string, Function> functions);

    }
}
