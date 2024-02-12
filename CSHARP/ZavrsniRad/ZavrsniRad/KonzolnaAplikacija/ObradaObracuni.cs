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
        public List<Obracun> Obracuni { get; }
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
            Thread.Sleep(2000);
            Console.WriteLine("***********************************************************");
            Console.WriteLine("Odaberite jedanu od ponuđenih mogučnosti rada s obračunima ");
            Console.WriteLine("***********************************************************");

            Thread.Sleep(2000);

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
                    Thread.Sleep(2000);
                    PrikaziIzbornik();
                    break;
                case 2:
                    DodajNoviObracun();
                    Thread.Sleep(2000);
                    PrikaziIzbornik();
                    break;
                case 3:
                    IzmjeniObracun();
                    Thread.Sleep(2000);
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiObracun();
                    Thread.Sleep(2000);
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Završili ste s radom na obračunima! ");
                    Thread.Sleep(2000);
                    break;

            }
        }

        private void DodajNoviObracun()
        {

            var o = new Obracun();

            o.Sifra = Pomocno.UcitajCijeliBroj("Unesite šifru obračuna: ", "Šifra obračuna mora biti pozivni cijeli broj");
            o.Radnici = DodjeliRadnikeObracunu();

            o.BrojRadnihSati = Math.Round(Pomocno.UcitajDecimalnibroj("Unesite koliko je sati radnik odradio: ", "Broj radnih sati mora biti cijeli broj broj"), 2);
            o.CijenaRadnogSata = Math.Round(Pomocno.UcitajDecimalnibroj("Unesite cijenu radnog sata radnika: ", "Cijena radnog sata mora biti decimalni broj"), 2);
            o.KoeficijentRadnogMjesta = Math.Round(Pomocno.UcitajDecimalnibroj("Unesite koeficijent radnog mjesta ", "Koeficijent radnog mjesta mora biti decimalni broj"), 2);
            
            o.BrutoI = Math.Round(o.BrojRadnihSati * o.CijenaRadnogSata * o.KoeficijentRadnogMjesta, 2);
            
            o.UdioZaPrviMirovnisnkiStup = Math.Round(((Pomocno.UcitajDecimalnibroj("Unesite postotak za prvi mirovinski stup: ", "Unos mora biti decimalni broj ")) / 100) * o.BrutoI, 2);
            o.UdioZaDrugiMirovnisnkiStup = Math.Round(((Pomocno.UcitajDecimalnibroj("Unesite postotak za drugi mirovinski stup: ", "Unos mora biti decimalni broj")) / 100) * o.BrutoI, 2);

            o.BrutoII = Math.Round(o.BrutoI - (o.UdioZaPrviMirovnisnkiStup + o.UdioZaDrugiMirovnisnkiStup), 2);


            o.OsnovniOsobniOdbitak = Math.Round(Pomocno.UcitajDecimalnibroj("Unesite iznos osnovnog osobnog odbitaka: ", "Unos mora biti decimalni broj"), 2);
            o.PoreznaOsnovica = Math.Round(o.BrutoII - o.OsnovniOsobniOdbitak, 2);
            o.PorezNaDohodak = Math.Round(((Pomocno.UcitajDecimalnibroj("Unesite postotak poreza na dohodak: ", "Unos mora biti decimalni broj ")) / 100), 2);
            
            o.NetoIznosZaIsplatuRadniku = Math.Round(o.BrutoII - (o.PorezNaDohodak*o.PoreznaOsnovica), 2);
            Obracuni.Add(o);

        }

        private List<Radnik> DodjeliRadnikeObracunu()
        {
            List<Radnik> radnici = new List<Radnik>();

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
            if(Obracuni.Count != 0)
            {
                PrikaziSveObracune();
                int index = Pomocno.UcitajRasponBrojeva("Odaberi redni broj obračuna: ", "Nije dobar odabir", 1, Obracuni.Count());
                var o = Obracuni[index - 1];
                Console.WriteLine("1. Izmjeni šifru obračuna ");
                Console.WriteLine("2. Izmjeni radnika na kojeg se odnosi obračun ");
                Console.WriteLine("3. Izmjeni broj radnih sati ");
                Console.WriteLine("4. Izmjeni cijenu radnog sata ");
                Console.WriteLine("5. Izmjeni koeficijent radnog mjesta ");
                Console.WriteLine("6. Izmjeni postotak za prvi mirovinski stup ");
                Console.WriteLine("7. Izmjeni postotak za drugi mirovinski stup ");
                Console.WriteLine("8. Izmjeni iznos osnovnog osobnog odbitka ");
                Console.WriteLine("9. Izmjenite postotak poreza na dohodak ");
                Console.WriteLine("0. Odustanite od promjena podataka o obračunu ");

                switch (Pomocno.UcitajRasponBrojeva("Odaberite broj između između 0-9 za rad s izbornikom promjena podataka o radniku: ", "Odabreni broj mora biti između 0-9 ", 0, 9))
                {
                    case 1:
                        o.Sifra = Pomocno.UcitajCijeliBroj("Unesite šifru obračuna ", "Šifra obračuna mora biti pozivni cijeli broj");
                        PrikaziSveObracune();
                        break;
                    case 2:
                        o.Radnici = DodjeliRadnikeObracunu();
                        PrikaziSveObracune();
                        break;
                    case 3:

                        o.BrojRadnihSati = Math.Round(Pomocno.UcitajDecimalnibroj("Unesite koliko je sati radnik odradio: ", "Broj radnih sati mora biti cijeli broj broj"), 2);

                        //Moramo promjeniti sve ostalo na što utječe  promljenjena varijabla
                        o.BrutoI = Math.Round(o.BrojRadnihSati * o.CijenaRadnogSata * o.KoeficijentRadnogMjesta, 2);
                        o.BrutoII = Math.Round(o.BrutoI - (o.UdioZaPrviMirovnisnkiStup + o.UdioZaDrugiMirovnisnkiStup), 2);
                        o.PoreznaOsnovica = Math.Round(o.BrutoII - o.OsnovniOsobniOdbitak, 2);
                        o.NetoIznosZaIsplatuRadniku = Math.Round(o.BrutoII - (o.PorezNaDohodak * o.PoreznaOsnovica), 2);

                        PrikaziSveObracune();
                        break;
                    case 4:
                        o.CijenaRadnogSata = Math.Round(Pomocno.UcitajDecimalnibroj("Unesite cijenu radnog sata radnika: ", "Cijena radnog sata mora biti decimalni broj"), 2);

                        //Moramo promjeniti sve ostalo na što utječe  promljenjena varijabla
                        o.BrutoI = Math.Round(o.BrojRadnihSati * o.CijenaRadnogSata * o.KoeficijentRadnogMjesta, 2);
                        o.BrutoII = Math.Round(o.BrutoI - (o.UdioZaPrviMirovnisnkiStup + o.UdioZaDrugiMirovnisnkiStup), 2);
                        o.PoreznaOsnovica = Math.Round(o.BrutoII - o.OsnovniOsobniOdbitak, 2);
                        o.NetoIznosZaIsplatuRadniku = Math.Round(o.BrutoII - (o.PorezNaDohodak * o.PoreznaOsnovica), 2);

                        PrikaziSveObracune();
                        break;
                    case 5:
                        o.KoeficijentRadnogMjesta = Math.Round(Pomocno.UcitajDecimalnibroj("Unesite koeficijent radnog mjesta ", "Koeficijent radnog mjesta mora biti decimalni broj"), 2);

                        //Moramo promjeniti sve ostalo na što utječe  promljenjena varijabla
                        o.BrutoI = Math.Round(o.BrojRadnihSati * o.CijenaRadnogSata * o.KoeficijentRadnogMjesta, 2);
                        o.BrutoII = Math.Round(o.BrutoI - (o.UdioZaPrviMirovnisnkiStup + o.UdioZaDrugiMirovnisnkiStup), 2);
                        o.PoreznaOsnovica = Math.Round(o.BrutoII - o.OsnovniOsobniOdbitak, 2);
                        o.NetoIznosZaIsplatuRadniku = Math.Round(o.BrutoII - (o.PorezNaDohodak * o.PoreznaOsnovica), 2);

                        PrikaziSveObracune();
                        break;
                    case 6:
                        o.UdioZaPrviMirovnisnkiStup = Math.Round(((Pomocno.UcitajDecimalnibroj("Unesite postotak za prvi mirovinski stup: ", "Unos mora biti decimalni broj ")) / 100) * o.BrutoI, 2);

                        //Moramo promjeniti sve ostalo na što utječe  promljenjena varijabla
                        o.BrutoI = Math.Round(o.BrojRadnihSati * o.CijenaRadnogSata * o.KoeficijentRadnogMjesta, 2);
                        o.BrutoII = Math.Round(o.BrutoI - (o.UdioZaPrviMirovnisnkiStup + o.UdioZaDrugiMirovnisnkiStup), 2);
                        o.PoreznaOsnovica = Math.Round(o.BrutoII - o.OsnovniOsobniOdbitak, 2);
                        o.NetoIznosZaIsplatuRadniku = Math.Round(o.BrutoII - (o.PorezNaDohodak * o.PoreznaOsnovica), 2);

                        PrikaziSveObracune();
                        break;
                    case 7:
                        o.UdioZaDrugiMirovnisnkiStup = Math.Round(((Pomocno.UcitajDecimalnibroj("Unesite postotak za drugi mirovinski stup: ", "Unos mora biti decimalni broj")) / 100) * o.BrutoI, 2);

                        //Moramo promjeniti sve ostalo na što utječe  promljenjena varijabla
                        o.BrutoI = Math.Round(o.BrojRadnihSati * o.CijenaRadnogSata * o.KoeficijentRadnogMjesta, 2);
                        o.BrutoII = Math.Round(o.BrutoI - (o.UdioZaPrviMirovnisnkiStup + o.UdioZaDrugiMirovnisnkiStup), 2);
                        o.PoreznaOsnovica = Math.Round(o.BrutoII - o.OsnovniOsobniOdbitak, 2);
                        o.NetoIznosZaIsplatuRadniku = Math.Round(o.BrutoII - (o.PorezNaDohodak * o.PoreznaOsnovica), 2);

                        PrikaziSveObracune();
                        break;
                    case 8:
                        o.OsnovniOsobniOdbitak = Math.Round(Pomocno.UcitajDecimalnibroj("Unesite iznos osnovnog osobnog odbitaka: ", "Unos mora biti decimalni broj"), 2);

                        //Moramo promjeniti sve ostalo na što utječe  promljenjena varijabla
                        o.BrutoI = Math.Round(o.BrojRadnihSati * o.CijenaRadnogSata * o.KoeficijentRadnogMjesta, 2);
                        o.BrutoII = Math.Round(o.BrutoI - (o.UdioZaPrviMirovnisnkiStup + o.UdioZaDrugiMirovnisnkiStup), 2);
                        o.PoreznaOsnovica = Math.Round(o.BrutoII - o.OsnovniOsobniOdbitak, 2);
                        o.NetoIznosZaIsplatuRadniku = Math.Round(o.BrutoII - (o.PorezNaDohodak * o.PoreznaOsnovica), 2);

                        PrikaziSveObracune();
                        break;
                    case 9:
                        o.PorezNaDohodak = Math.Round(((Pomocno.UcitajDecimalnibroj("Unesite postotak poreza na dohodak: ", "Unos mora biti decimalni broj ")) / 100) * o.PoreznaOsnovica, 2);

                        //Moramo promjeniti sve ostalo na što utječe  promljenjena varijabla
                        o.BrutoI = Math.Round(o.BrojRadnihSati * o.CijenaRadnogSata * o.KoeficijentRadnogMjesta, 2);
                        o.BrutoII = Math.Round(o.BrutoI - (o.UdioZaPrviMirovnisnkiStup + o.UdioZaDrugiMirovnisnkiStup), 2);
                        o.PoreznaOsnovica = Math.Round(o.BrutoII - o.OsnovniOsobniOdbitak, 2);
                        o.NetoIznosZaIsplatuRadniku = Math.Round(o.BrutoII - (o.PorezNaDohodak * o.PoreznaOsnovica), 2);

                        PrikaziSveObracune();
                        break;
                    case 0:
                        PrikaziSveObracune();
                        break;

                }

            } 
            else
            {
                Console.WriteLine("Prvo morate unjeti obračun kako biste mogli promljeniti podatke o obračunu ");
                if (Pomocno.UcitajBool("Želite li dodati novi obračun? (da ili bilo što drugo za ne): "))
                {
                    DodajNoviObracun();
                }
                else
                {
                    Console.WriteLine("Slijedi povratak na glavni izbornik rada s obračunima ");
                    Thread.Sleep(2000);
                    PrikaziIzbornik();
                }
            }

        }

        private void ObrisiObracun()
        {
            PrikaziSveObracune();
            int index = Pomocno.UcitajRasponBrojeva("Odaberi redni broj obračuna: ", "Nije dobar odabir", 1, Obracuni.Count());
            Obracuni.RemoveAt(index - 1); ;
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
