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
        /// <summary>
        /// Prezime radnika u bazi
        /// </summary>
        [Required(ErrorMessage = "Jedinična cijena radnog sata ja obavezna")]
        public decimal? CijenaRadnogSata { get; set; }

        /// <summary>
        /// Prezime radnika u bazi
        /// </summary>
        [Required(ErrorMessage = "Koeficijent radnog mjesta je obavezan")]
        public decimal? KoeficijentRadnogMjesta { get; set; }

        //Bruto I = CijenaRadnogSata*BrojRadnihSati*KoeficijentRadnnogMjesta
        public decimal? BrutoI { get; set; }

        //BrurtoII = BrutoI - (MIO I + MIO II) - služi kao porezna osnovica
        public decimal? BrutoII { get; set; }


    }
}
