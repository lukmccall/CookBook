namespace client_generator.Models
{
    public interface ISchema
    {

        string GetName();

        FieldType GetFieldType();

        bool WasGenerated();

        void Generate();

    }
}
