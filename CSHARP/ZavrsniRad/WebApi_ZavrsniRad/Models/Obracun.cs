using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_ZavrsniRad.Models
{
    public class Obracun:Odbitak
    {
        [ForeignKey("radnik")]
        public Radnik? Radnik{ get; set; }
        /// <summary>
        /// Datum obračuna
        /// </summary>
        public DateTime? DatumObracuna { get; set; }
        /// <summary>
        /// Prezime radnika u bazi
        /// </summary>
        //[Required(ErrorMessage = "Broj radnih sati koje je radnik odradio u razdoblju obračuna je obavezan")]
        public int? BrojRadnihSati { get; set; }
        //Bruto I = CijenaRadnogSata*BrojRadnihSati*KoeficijentRadnnogMjesta
        public decimal? Bruto_I { get; set; }

        //BrurtoII = BrutoI - (MIO I + MIO II) - služi kao porezna osnovica
        public decimal? Bruto_II { get; set; }

        public decimal? NetoIznosZaIsplatu { get; set; }


    }
}
