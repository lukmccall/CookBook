using client_generator.Models;

namespace client_generator.OpenApi._3._0._1.Referable
{
    public class ReferableDataWrapper<T> : IReferable<T>

    {
        private readonly T _parameter;

        public ReferableDataWrapper(T parameter)
        {
            _parameter = parameter;
        }

        public T GetObject()
        {
            return _parameter;
        }

        public string GetRef()
        {
            return null;
        }
    }
}