using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavršniRad.KonzolnaAplikacijaUjednojKlasi.Model;

namespace ZavršniRad.KonzolnaAplikacijaUjednojKlasi
{
    internal class Program
    {
        private List<Radnik> Radnici;
        public Program()
        {
            Radnici = new List<Radnik>();

            PozdravnaPoruka();
            GlavniIzbornik();



        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("********OBRACUN PLAČA BY LENY_V1*******");
            Console.WriteLine("***************************************");
        }
        //**************GLAVNI IZBORNIK**************
        private void GlavniIzbornik()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Glavni izbornik");
            Console.WriteLine("**********************************************");
            Console.WriteLine("Odaberite jedanu od ponuđenih mogučnosti rada ");
            Console.WriteLine("**********************************************");
            Console.WriteLine("1. Rad s podacima o radnicima ");
            Console.WriteLine("2. Rad s obračunima ");
            Console.WriteLine("3. Rad s plačama ");
            Console.WriteLine("4. Izlaz iz programa ");

            OdabirGlavniIzborniki();

        }

        private void OdabirGlavniIzborniki()
        {
            switch (Pomocno.UcitajRasponBrojeva("Odaberite broj između između 1-4 za rad s glavnim izbornikom: ", "Odabreni broj mora biti između 1-4 ", 1, 4))
            {
                case 1:
                    IzbornikRadSaPodacimaORadnicima();
                    break;
                case 2:
                    IzbornikRadaSaObracunima();
                    break;
                case 3:
                    IzbornikRadaSaPlacama();
                    break;
                case 4:
                    Console.WriteLine("******************************************");
                    Console.WriteLine("Hvala na korištenju aplikaije. Doviđenja!!");
                    Console.WriteLine("******************************************");
                    break;

            }
        }

        //**************RADNICI**************

        private void IzbornikRadSaPodacimaORadnicima()
        {
            Console.WriteLine("**********************************************");
            Console.WriteLine("Odaberite jedanu od ponuđenih mogučnosti rada ");
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
            switch(Pomocno.UcitajRasponBrojeva("Odaberite broj između između 1-5 za rad s glavnim izbornikom: ", "Odabreni broj mora biti između 1-5 ", 1, 5))
            {
                case 1:
                    PrikaziSveRadnike();
                    break;
                case 2:
                    DodajRandika();
                    break;
                case 3:
                    UrediPodatkeORadniku();
                    break;
                case 4:
                    ObrisiRadnika();
                    break;
                case 5:
                    GlavniIzbornik();
                    break;

            }
        }



        private void PrikaziSveRadnike()
        {
            throw new NotImplementedException();
        }
        private void DodajRandika()
        {
            throw new NotImplementedException();
        }


        private void UrediPodatkeORadniku()
        {
            throw new NotImplementedException();
        }

        private void ObrisiRadnika()
        {
            throw new NotImplementedException();
        }

        //**************OBRACUNI**************
        private void IzbornikRadaSaObracunima()
        {
            
        }

        private void IzbornikRadaSaPlacama()
        {

        }
    }
}

