namespace client_generator.Deserializer
{
    public interface ISuspendBuilder<out T>
    {
        void Parse();
        bool CanCreate();
        T Create();
    }
}