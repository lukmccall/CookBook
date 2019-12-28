namespace client_generator.OpenApi._3._0._1.Converters
{
    public interface ISuspendBuilder<T>
    {
        void Parse();
        bool CanCreate();
        T Create();
    }
}