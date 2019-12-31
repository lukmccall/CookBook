using System;

namespace CookBook.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class Mappable : Attribute
    {
        public Type To { get; set; }
    }
}