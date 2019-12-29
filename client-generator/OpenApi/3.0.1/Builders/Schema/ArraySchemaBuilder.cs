using System.Collections.Generic;
using client_generator.Deserializer.Helpers.Builders;
using client_generator.Models;

namespace client_generator.OpenApi._3._0._1.Builders.Schema
{
    public class ArraySchemaBuilder : ISuspendBuilder<ISchema>
    {

        private readonly string _neededPath;

        private readonly Dictionary<string, ISchema> _schemes;

        private ISchema _schema;

        public ArraySchemaBuilder(string neededPath, Dictionary<string, ISchema> schemes)
        {
            _neededPath = neededPath;
            _schemes = schemes;
        }

        public void Parse()
        {
            if (_schema == null)
            {
                if (_schemes.ContainsKey(_neededPath))
                {
                    _schema = _schemes[_neededPath];
                }
            }
        }

        public bool CanCreate()
        {
            return _schema != null;
        }

        public ISchema Create()
        {
            return new ArraySchema(_schema);
        }

    }
}
