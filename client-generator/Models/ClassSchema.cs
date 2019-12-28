using System.Collections.Generic;

namespace client_generator.Models
{
    public class ClassSchema : ISchema
    {
        private bool _wasGenerated = false;
        private readonly string _name;
        private readonly Dictionary<string, ISchema> _properties;

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