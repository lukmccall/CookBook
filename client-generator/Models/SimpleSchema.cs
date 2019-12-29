using System.Collections.Generic;

namespace client_generator.Models
{
    internal class SimpleSchema : ISchema
    {

        private static readonly Dictionary<FieldType, string> TypeToName = new Dictionary<FieldType, string>
        {
            {FieldType.Int, "number"},
            {FieldType.Number, "number"},
            {FieldType.Bool, "bool"},
            {FieldType.String, "string"}
        };

        private readonly FieldType _type;

        public SimpleSchema(FieldType type)
        {
            _type = type;
        }

        public string GetName()
        {
            return TypeToName.ContainsKey(_type) ? TypeToName[_type] : "any";
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
            // we don't have to generate code 
        }

    }
}
