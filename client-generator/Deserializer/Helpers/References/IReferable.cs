namespace client_generator.Deserializer.Helpers.References
{
    public interface IReferable<out T>
    {

        T GetObject();

        string GetRef();

    }
}
