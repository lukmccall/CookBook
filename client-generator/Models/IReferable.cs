namespace client_generator.Models
{
    public interface IReferable<out T>
    {
        T GetObject();

        string GetRef();
    }
}