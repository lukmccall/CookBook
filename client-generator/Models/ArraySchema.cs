namespace client_generator.Models
{
    public class ArraySchema : ISchema
    {
        private readonly ISchema _schema;

        public ArraySchema(ISchema schema)
        {
            _schema = schema;
        }

        public string GetName()
        {
            return $"Array<{_schema.GetName()}>";
        }

        public FieldType GetFieldType()
        {
            return FieldType.Array;
        }

        public bool WasGenerated()
        {
            return _schema.WasGenerated();
        }

        public void Generate()
        {
            _schema.Generate();
        }
    }
}