using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavršniRad.KonzolnaAplikacija;
using ZavrsniRad.KonzolnaAplikacija.Model;
using ZavršniRad.KonzolnaAplikacija.Model;

namespace ZavrsniRad.KonzolnaAplikacija
{
    internal class ObradaPlace
    {
        public List<Placa> Place { get; }
        private GlavniIzbornik GlavniIzbornik;

        public void PrikaziIzbornik()
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine("Odaberite jedanu od ponuđenih mogučnosti rada s plačama ");
            Console.WriteLine("**********************************************************");

            Thread.Sleep(3000);

            Console.WriteLine("1. Prikaži sve plače ");
            Console.WriteLine("2. Dodaj plaču ");
            Console.WriteLine("3. Izmjeni  o plači ");
            Console.WriteLine("4. Obriši plaču ");
            Console.WriteLine("5. Povratak na prethodni izbornik ");

            Thread.Sleep(3000);

            OdabirIzbornikRadaSaPlacama();
        }

        private void OdabirIzbornikRadaSaPlacama()
        {
            switch (Pomocno.UcitajRasponBrojeva("Odaberite broj između između 1-5 za rad s radnicima: ", "Odabreni broj mora biti između 1-5 ", 1, 5))
            {
                case 1:
                    PrikaziSvePlace();
                    Thread.Sleep(2000);
                    PrikaziIzbornik();
                    break;
                case 2:
                    DodajPlacu();
                    Thread.Sleep(2000);
                    PrikaziIzbornik();
                    break;
                case 3:
                    UrediPodatkeOPlaci();
                    Thread.Sleep(2000);
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiPlacu();
                    Thread.Sleep(2000);
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Završili ste s radom na plačama. ");
                    Thread.Sleep(2000);
                    break;
            }
        }

        

        private void PrikaziSvePlace()
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("*****************Unesene plače*****************");
            Console.WriteLine("***********************************************");

            Thread.Sleep(1000);
            var b = 1;

            foreach (Placa placa in Place)
            {
                Console.WriteLine("{0}. {1}", b++, placa);
            }

            Console.WriteLine("///////////////////////////////////////////////"); ;
        }

        private void DodajPlacu()
        {
            var p = new Placa();

            p.Sifra = Pomocno.UcitajCijeliBroj("Unesite šifru plaće: ", "Šifra plaće mora biti pozivni cijeli broj");
            p.NazivPlace = Pomocno.UcitajString("Unesite naziv plaće: ", "Naziv plaće je obavezan ");

            p.Obracun = DodjeliObracunePlaci();

        }

        private Obracun DodjeliObracunePlaci()
        {
            throw new NotImplementedException();
        }

        private void UrediPodatkeOPlaci()
        {
            throw new NotImplementedException();
        }

        private void ObrisiPlacu()
        {
            throw new NotImplementedException();
        }
    }
}
