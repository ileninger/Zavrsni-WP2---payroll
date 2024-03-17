using System.ComponentModel.DataAnnotations;

namespace WebApi_ZavrsniRad.Models
{
    public class Obracun:Odbitak
    {
        public List<Radnik> Radnici { get; set; }
        /// <summary>
        /// Datum obračuna
        /// </summary>
        public DateTime? DatumObracuna { get; set; }
        /// <summary>
        /// Prezime radnika u bazi
        /// </summary>
        [Required(ErrorMessage = "Broj radnih sati koje je radnik odradio u razdoblju obračuna je obavezan")]
        public decimal? BrojRadnihSati { get; set; }
        //Bruto I = CijenaRadnogSata*BrojRadnihSati*KoeficijentRadnnogMjesta
        public decimal? BrutoI { get; set; }

        //BrurtoII = BrutoI - (MIO I + MIO II) - služi kao porezna osnovica
        public decimal? BrutoII { get; set; }


    }
}
