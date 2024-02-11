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
    internal class ObradaObracuni
    {
        public List <Obracun> Obracuni  {  get; }
        private GlavniIzbornik GlavniIzbornik;

        public ObradaObracuni(GlavniIzbornik glavniIzbornik) : this()
        {
            this.GlavniIzbornik = glavniIzbornik;
        }

        public ObradaObracuni()
        {
            Obracuni = new List<Obracun>();
        }

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
            switch (Pomocno.UcitajRasponBrojeva("Odaberite broj između između 1-5 za rad s po: ", "Odabreni broj mora biti između 1-5 ", 1, 5))
            {
                case 1:
                    PrikaziSveObracune();
                    PrikaziIzbornik();
                    break;
                case 2:
                    DodajNoviObracun();
                    PrikaziIzbornik();
                    break;
                case 3:
                    IzmjeniObracun();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiObracun();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Završili ste s radom na obračunima! ");
                    break;

            }
        }

        private void DodajNoviObracun()
        {

            var o = new Obracun();

            o.Sifra = Pomocno.UcitajCijeliBroj("Unesite šifru obračuna: ", "Šifra obračuna mora biti pozivni cijeli broj");
            o.Radnici = DodjeliRadnikeObracunu();
            o.CijenaRadnogSata = Pomocno.UcitajDecimalnibroj("Unesite cijenu radnog sata radnika: ", "Cijena radnog sata mora biti decimalni broj");
            Obracuni.Add(o);




        }

        private List<Radnik> DodjeliRadnikeObracunu()
        {
            List <Radnik> radnici = new List<Radnik>();

            while (Pomocno.UcitajBool("Želite li dodati radnika obračunu? (da ili bilo što drugo za ne): "))
            {
                radnici.Add(DodjeliRadnikaObracunu());
            }
            return radnici;

        }

        private Radnik DodjeliRadnikaObracunu()
        {
            GlavniIzbornik.ObradaRadnici.PrikaziSveRadnike();
            int index = Pomocno.UcitajRasponBrojeva("Odaberi redni broj radnika: ", "Nije dobar odabir", 1, GlavniIzbornik.ObradaRadnici.Radnici.Count());
            return GlavniIzbornik.ObradaRadnici.Radnici[index - 1];

        }

        private void IzmjeniObracun()
        {
            throw new NotImplementedException();
        }

        private void ObrisiObracun()
        {
            throw new NotImplementedException();
        }

        private void PrikaziSveObracune()
        {
            Console.WriteLine("************************************************");
            Console.WriteLine("********************Obračuni********************");
            Console.WriteLine("************************************************");

            var i = 0;
            Obracuni.ForEach(s =>
            {
                Console.WriteLine(++i + "." + s);
            });
            Console.WriteLine("///////////////////////////////////////////////");
        }
    }
}
