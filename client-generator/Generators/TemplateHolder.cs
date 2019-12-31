using client_generator.Templates;

namespace client_generator.Generators
{
    public abstract class TemplateHolder : IGenerable
    {

        protected ITemplate Template;

        public virtual void SetTemplate(ITemplate template)
        {
            Template = template;
        }

        public abstract bool NeedsToBeGenerated();

        public abstract void Generate(IGeneratorContext generator);

    }
}
