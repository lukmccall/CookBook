using client_generator.Templates;

namespace client_generator.Generators
{
    public interface IGenerable
    {

        void SetTemplate(ITemplate template);

        bool NeedsToBeGenerated();

        void Generate(IGeneratorContext generator);
        

    }
}
