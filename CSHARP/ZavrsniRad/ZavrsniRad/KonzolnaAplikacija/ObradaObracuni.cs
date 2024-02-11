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
            switch (Pomocno.UcitajRasponBrojeva("Odaberite broj između između 1-5 za rad s obračunima: ", "Odabreni broj mora biti između 1-5 ", 1, 5))
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
            bool Prirez;

            o.Sifra = Pomocno.UcitajCijeliBroj("Unesite šifru obračuna: ", "Šifra obračuna mora biti pozivni cijeli broj");
            o.Radnici = DodjeliRadnikeObracunu();

            o.BrojRadnihSati = Math.Round(Pomocno.UcitajDecimalnibroj("Unesite koliko je sati radnik odradio: ", "Broj radnih sati mora biti cijeli broj broj"),2);
            o.CijenaRadnogSata = Math.Round(Pomocno.UcitajDecimalnibroj("Unesite cijenu radnog sata radnika: ", "Cijena radnog sata mora biti decimalni broj"),2);
            o.KoeficijentRadnogMjesta = Math.Round(Pomocno.UcitajDecimalnibroj("Unesite koeficijent radnog mjesta ", "Koeficijent radnog mjesta mora biti decimalni broj"),2);
            o.BrutoI = Math.Round(o.BrojRadnihSati*o.CijenaRadnogSata*o.KoeficijentRadnogMjesta,2);
            o.UdioZaPrviMirovnisnkiStup = Math.Round(((Pomocno.UcitajDecimalnibroj("Unesite postotak za prvi mirovinski stup: ","Unos mora biti decimalni broj ")) / 100)*o.BrutoI,2);
            o.UdioZaDrugiMirovnisnkiStup =Math.Round(((Pomocno.UcitajDecimalnibroj("Unesite postotak za drugi mirovinski stup: ", "Unos mora biti decimalni broj")) / 100) * o.BrutoI,2);

            o.BrutoII = Math.Round(o.BrutoI - (o.UdioZaPrviMirovnisnkiStup + o.UdioZaDrugiMirovnisnkiStup),2);
            
            if(!Pomocno.UcitajBool("Postoji li za radnikovu prijavljenu adresu faktor korekcije poreza prireza: (da ili bilo što drugo za ne): "))
            {
                o.NetoIznosZaIsplatuRadniku = Math.Round(o.BrutoII,2);
            }
            else {
                o.OsnovniOsobniOdbitak = Math.Round(Pomocno.UcitajDecimalnibroj("Unesite osnovni osobni odbitak: ", "Unos mora biti decimalni broj"),2);
                o.PoreznaOsnovica = Math.Round(o.BrutoII - o.OsnovniOsobniOdbitak,2);
                o.FaktorKorekcijePorezaPrireza = Math.Round(((Pomocno.UcitajDecimalnibroj("Unesite faktor korekcije poreza i preireza: ", "Unos mora biti decimalni broj ")) / 100)*o.PoreznaOsnovica,2);
                o.NetoIznosZaIsplatuRadniku = Math.Round(o.BrutoII - o.FaktorKorekcijePorezaPrireza,2);
                 

            }
           
            
            

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
