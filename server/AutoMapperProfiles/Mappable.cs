using AutoMapper;

namespace CookBook.AutoMapperProfiles
{
    public class Mappable : Profile
    {

        public Mappable()
        {
            foreach (var type in typeof(Startup).Assembly.GetTypes())
            {
                var attribs = type.GetCustomAttributes(typeof(Attributes.Mappable), false);
                foreach (Attributes.Mappable attrib in attribs)
                {
                    CreateMap(type, attrib.To);
                }
            }
        }

    }
}
