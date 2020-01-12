namespace client_generator.Deserializer.Helpers.Builders
{
    public interface ISuspendBuilder<out T>
    {

        void Parse();

        bool CanCreate();

        T Create();

    }
}
