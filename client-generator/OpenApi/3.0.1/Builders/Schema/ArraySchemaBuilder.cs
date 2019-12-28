using System.Collections.Generic;
using client_generator.Models;

namespace client_generator.OpenApi._3._0._1.Builders.Schema
{
    public class ArraySchemaBuilder : ISuspendBuilder<ISchema>
    {
        private readonly string _neededPath;
        private readonly Dictionary<string, ISchema> _schemata;
        private ISchema _schema;

        public ArraySchemaBuilder(string neededPath, Dictionary<string, ISchema> schemata)
        {
            _neededPath = neededPath;
            _schemata = schemata;
        }

        public void Parse()
        {
            if (_schema == null)
            {
                if (_schemata.ContainsKey(_neededPath))
                {
                    _schema = _schemata[_neededPath];
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