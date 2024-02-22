using System.ComponentModel.DataAnnotations;

namespace WebApi_ZavrsniRad.Models
{
    /// <summary>
    /// Ovo mi je POCO koji je mapiran na bazu 
    /// </summary>
    public class Radnik:Entitet
    {
        /// <summary>
        /// Ime radnika u bazi 
        /// </summary>
        [Required(ErrorMessage ="Ime radnika je obavezno")]
        public string? Ime { get; set; }

        public string? Prezime { get; set; }

        public string? OiB { get; set; }

        public DateTime? DatumZaposlenja { get; set; }

        public string? Iban { get; set; }
    }
}


//public string Ime { get; set; }

//public string Prezime { get; set; }

//public string OiB { get; set; }

//public DateTime DatumZaposlenja { get; set; }

//public string Iban { get; set; }