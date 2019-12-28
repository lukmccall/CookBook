using System.Collections.Generic;
using client_generator.Models;

namespace client_generator.OpenApi._3._0._1.Referable
{
    public interface IReferenceCollector
    {
        void Visit(string reference, IReferable<object> obj);

        bool Validate();

        Dictionary<string, T> GetObjectOfType<T>();
    }
}