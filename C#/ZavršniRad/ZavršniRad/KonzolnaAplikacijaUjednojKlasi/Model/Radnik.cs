using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad.KonzolnaAplikacijaUjednojKlasi.Model
{
    internal class Radnik:Entitet
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }
      
        public string OiB { get; set; }

        public DateOnly DatumZaposlenja { get; set; }

        public string Iban { get; set; }

    }
}
