using System;
using System.Collections.Generic;

namespace client_generator.OpenApi._3._0._1.Referable
{
    public static class ReferableList
    {
        public static Dictionary<Type, string> GetRefMap()
        {
            return new Dictionary<Type, string>
            {
                {typeof(Schema), "schemas"},
                {typeof(Response), "responses"},
                {typeof(Parameter), "parameters"},
                {typeof(Request), "requestBodies"},
                {typeof(Header), "headers"},
            };
        }
    }
}