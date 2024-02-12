using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavrsniRad.KonzolnaAplikacija.Model;

namespace ZavrsniRad.KonzolnaAplikacija
{
    internal class ObradaPlace
    {
        public List<Placa> Place { get; }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine("Odaberite jedanu od ponuđenih mogučnosti rada s plačama ");
            Console.WriteLine("**********************************************************");
            Console.WriteLine("1. Prikaži sve plače ");
            Console.WriteLine("2. Dodaj plaču ");
            Console.WriteLine("3. Izmjeni  o plači ");
            Console.WriteLine("4. Obriši plaču ");
            Console.WriteLine("5. Povratak na prethodni izbornik ");
        }
    }
}
