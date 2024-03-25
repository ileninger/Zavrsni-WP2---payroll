using AutoMapper;
using WebApi_ZavrsniRad.Models;

namespace WebApi_ZavrsniRad.Mappers
{
    public class RadnikMapper
    {
        public static Mapper InicijalizirajRead()
        {
            return new Mapper(
                    new MapperConfiguration(c=>
                    {
                        c.CreateMap<Radnik, RadnikDTORead>();
                    })
                );
        }
        public static Mapper InicijalizirajInsertUpdate()
        {
            return new Mapper(
                    new MapperConfiguration(c =>
                    {
                        c.CreateMap<Radnik, RadnikDTOInsertUpdate>();
                    })
                );
        }
    }
}
