using System.Collections.Generic;

namespace client_generator.Models
{
    public class ClassSchema : ISchema
    {

        private readonly string _name;

        private readonly Dictionary<string, ISchema> _properties;

        private bool _wasGenerated;

        public ClassSchema(string name, Dictionary<string, ISchema> properties)
        {
            _name = name;
            _properties = properties;
        }

        public string GetName()
        {
            return _name;
        }

        public FieldType GetFieldType()
        {
            return FieldType.Object;
        }

        public bool WasGenerated()
        {
            return _wasGenerated;
        }

        public void Generate()
        {
            _wasGenerated = true;
        }

    }
}
