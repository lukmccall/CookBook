using System;

namespace client_generator.Deserializer.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OpenApiDeserializer : Attribute
    {

        public string Version { get; set; }

    }
}
