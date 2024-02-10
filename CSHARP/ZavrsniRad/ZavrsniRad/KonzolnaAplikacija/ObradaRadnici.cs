using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavršniRad.KonzolnaAplikacija;
using ZavršniRad.KonzolnaAplikacija.Model;

namespace ZavrsniRad.KonzolnaAplikacija
{
    internal class ObradaRadnici
    {
        public List<Radnik> Radnici { get; }

        public ObradaRadnici()
        {
            Radnici = new List<Radnik>();
            if (Pomocno.Test)
            {
                TesniPodaci();
            }
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine("Odaberite jedanu od ponuđenih mogučnosti rada s radnicima ");
            Console.WriteLine("**********************************************");
            Console.WriteLine("1. Prikaži sve radnike ");
            Console.WriteLine("2. Dodaj radnika ");
            Console.WriteLine("3. Izmjeni  podatke o radniku ");
            Console.WriteLine("4. Obriši radnika ");
            Console.WriteLine("5. Povratak na prethodni izbornik ");
            OdabirIzbornikRadaSaPodacimaORadnicima();
        }

        private void OdabirIzbornikRadaSaPodacimaORadnicima()
        {
            switch (Pomocno.UcitajRasponBrojeva("Odaberite broj između između 1-5 za rad s glavnim izbornikom: ", "Odabreni broj mora biti između 1-5 ", 1, 5))
            {
                case 1:
                    PrikaziSveRadnike();
                    PrikaziIzbornik();
                    break;
                case 2:
                    DodajRandika();
                    PrikaziIzbornik();
                    break;
                case 3:
                    UrediPodatkeORadniku();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiRadnika();
                    break;
                case 5:
                    Console.WriteLine("Završili ste s radom na radnicima. ");
                    break;

            };
        }

        private void ObrisiRadnika()
        {
            PrikaziSveRadnike();
            int index = Pomocno.UcitajRasponBrojeva("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Radnici.Count());
            Radnici.RemoveAt(index - 1);
        }

        private void PrikaziSveRadnike()
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("****************Uneseni radnici****************");
            Console.WriteLine("***********************************************");
            
            var i = 0;
            Radnici.ForEach(s =>
            {
                Console.WriteLine(++i + "." + s);
            });
            Console.WriteLine("///////////////////////////////////////////////");
        }

        private void DodajRandika()
        {
            var radnik = new Radnik();
            bool IspravnostOiB = false;
            bool IspravnostIban = false;
            radnik.Sifra = Pomocno.UcitajCijeliBroj("Unesite šifru radnika: ", "Šifra radnika mora biti pozivni cijeli broj");
            radnik.Ime = Pomocno.UcitajString("Unesite ime radnika: ", "Ime radnika je obavezno ");
            radnik.Prezime = Pomocno.UcitajString("Unesite prezime radnika: ", "Prezime radnika je obavezno ");


            //Tražimo unos ispravnog OiB-a
            while (!IspravnostOiB)
            {
                radnik.OiB = Pomocno.UcitajString("Unesite OiB radnika: ", "OiB radnika je obavezan ");
                if (!Provjere.ProvjeriIspavnostOiB(radnik.OiB))
                {
                    Console.WriteLine("Unjeli ste neispravan OiB!!! ");
                }
                else {
                    IspravnostOiB=true;
                }
            }
           
            radnik.DatumZaposlenja = Pomocno.UcitajDatum("Unesite datum zaposlenja radnika u formatu dd.mm.yyyy ", "Datum zaposlenja radnika mora biti u formatu dd.mm.yyyy ");
            //Tražimo unos ispravnog Ibana
            while(!IspravnostIban)
            {
                radnik.Iban = Pomocno.UcitajString("Unesite Iban radnika s predznakom HR: ", "Niste unjeli dobar Iban, Iban račun mora započinjati s HR");
                if(!Provjere.ProvjeriIspravnostHrvatskogIBAN(radnik.Iban))
                {
                    Console.WriteLine("Unjeli ste neispravan Iban, Iban mora započinjati s HR!!");
                }
                else
                {
                    IspravnostIban=true;
                }
            }
           


            Radnici.Add(radnik);
            
        }

        private void UrediPodatkeORadniku()
        {
            PrikaziSveRadnike();
            int index = Pomocno.UcitajRasponBrojeva("Odaberi redni broj smjera: ", "Nije dobar odabir", 1, Radnici.Count());
            var s = Radnici[index - 1];
            s.Sifra = Pomocno.UcitajCijeliBroj("Unesite šifru radnika ", "Šifra radnika mora biti pozivni cijeli broj");
            s.Ime = Pomocno.UcitajString("Unesite ime radnika ", "Ime radnika je obavezno ");
            s.Prezime = Pomocno.UcitajString("Unesite prezime radnika ", "Prezime radnika je obavezno ");
            s.OiB = Pomocno.UcitajString("Unesite OiB radnika ", "OiB radnika je obavezan ");
            s.DatumZaposlenja = Pomocno.UcitajDatum("Unesite datum zaposlenja radnika u formatu dd.mm.yyyy ", "Datum zaposlenja radnika mora biti u formatu dd/mm/yyyy ");
            s.Iban = Pomocno.UcitajString("Unesite Iban radnika ", "Iban randika je obavezan"); ;
        }
        private void TesniPodaci()
        {
            Radnici.Add(new Radnik
            {
                Sifra = 1,
                Ime = "Ivan",
                Prezime = "Leninger",
                DatumZaposlenja = new DateTime(2017, 1, 26),
                OiB = "74203130129",
                Iban = "5023600003983799849"
            }); ;
        }
    }
}
