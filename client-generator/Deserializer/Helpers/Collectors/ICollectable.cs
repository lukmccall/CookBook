namespace client_generator.Deserializer.Helpers.Collectors
{
    public interface ICollectable<T>
    {

        void Accept(string path, T collector);

    }
}
