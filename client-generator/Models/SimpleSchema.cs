namespace client_generator.Models
{
    class SimpleSchema : ISchema
    {
        private readonly FieldType _type;

        public SimpleSchema(FieldType type)
        {
            _type = type;
        }

        public string GetName()
        {
            return "dsad";
        }

        public FieldType GetFieldType()
        {
            return _type;
        }

        public bool WasGenerated()
        {
            return false;
        }

        public void Generate()
        {
        }
    }
}