using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace client_generator.Deserializer.Attributes
{
    public class OpenApiDeserializerAssemblyIterator : IEnumerator<Type>
    {

        private readonly Type[] _allTypes;

        private int _index = -1;

        public OpenApiDeserializerAssemblyIterator(Type[] allTypes)
        {
            _allTypes = allTypes;
        }

        public bool MoveNext()
        {
            var nexIndex = FindNextIndex();

            if (_allTypes.Length > nexIndex)
            {
                _index = nexIndex;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _index = -1;
        }

        object IEnumerator.Current => Current;

        public Type Current => _allTypes[_index];


        public void Dispose()
        {
        }

        private int FindNextIndex()
        {
            for (var i = _index + 1; i < _allTypes.Length; i++)
            {
                if (_allTypes[i].GetCustomAttributes(typeof(OpenApiDeserializer)).Any())
                {
                    return i;
                }
            }

            return _allTypes.Length;
        }

    }
}
