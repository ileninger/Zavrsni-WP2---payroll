using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_ZavrsniRad.Models
{
    public class Placa:Entitet
    {
        [ForeignKey("obracun")]
        public Obracun? Obracun { get; set; }
        public string? NazivPlace { get; set; }
    }
}
