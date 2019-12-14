using System;
using AutoMapper;

namespace CookBook.AutoMapperProfiles
{
    public class Mappable : Profile
    {
        public Mappable()
        {
            foreach (var type in typeof(Startup).Assembly.GetTypes())
            {
                var attribs = type.GetCustomAttributes(typeof(CookBook.Attributes.Mappable), inherit: false);
                foreach (CookBook.Attributes.Mappable attrib in attribs)
                {
                    CreateMap(type, attrib.To);
                }
            }
        }
    }
}