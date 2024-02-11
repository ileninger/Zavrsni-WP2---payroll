using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavrsniRad.KonzolnaAplikacija.Model;

namespace ZavrsniRad.KonzolnaAplikacija
{
    internal class ObradaObracuni
    {
        public List <Odbitak> Odbici {  get; }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Odaberite jedanu od ponuđenih mogučnosti rada s obračunima ");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("1. Prikaži sve obračune ");
            Console.WriteLine("2. Dodaj obračun ");
            Console.WriteLine("3. Izmjeni obračun ");
            Console.WriteLine("4. Obriši obračun ");
            Console.WriteLine("5. Povratak na prethodni izbornik");

            OdabirIzbornikRadaSaObracunima();

        }

        private void OdabirIzbornikRadaSaObracunima()
        {
            throw new NotImplementedException();
        }
    }
}
