using WebApi_ZavrsniRad.Mappers;
using WebApi_ZavrsniRad.Models;

namespace WebApi_ZavrsniRad.Extensions
{
    public static class Mapping
    {
        public static List<RadnikDTORead> MapRadnikReadList(this List <Radnik> lista)
        {
            var mapper = RadnikMapper.InicijalizirajRead();
            var vrati = new List<RadnikDTORead>();
            lista.ForEach(e =>
            {
                vrati.Add(mapper.Map<RadnikDTORead>(e));
            });
            return vrati;
        }
    }
}
