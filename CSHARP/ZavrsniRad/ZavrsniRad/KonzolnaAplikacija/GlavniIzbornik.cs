using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZavrsniRad.KonzolnaAplikacija;
using ZavršniRad.KonzolnaAplikacija.Model;

namespace ZavršniRad.KonzolnaAplikacija
{
    internal class GlavniIzbornik
    {
        public ObradaRadnici ObradaRadnici { get; }

        public ObradaPlace ObradaPlace;
        
        public ObradaObracuni ObradaObracuni { get; }
        

        public GlavniIzbornik()
        {

            Pomocno.Test = true;
            ObradaRadnici = new ObradaRadnici();
            ObradaObracuni = new ObradaObracuni(this);
            ObradaPlace = new ObradaPlace();

            PozdravnaPoruka();
            GlavniIzbornikSucelje();



        }

       

        private void PozdravnaPoruka()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("********OBRACUN PLAČA BY LENY_V1*******");
            Console.WriteLine("***************************************");
        }
        //**************GLAVNI IZBORNIK**************
        public void GlavniIzbornikSucelje()
        {
            Console.WriteLine("\n");
            Thread.Sleep(1000);

            Console.WriteLine("************Glavni izbornik**************");
            Console.WriteLine("*****************************************");
            Console.WriteLine("Odaberite jedanu od ponuđenih mogučnosti ");
            Console.WriteLine("*****************************************");
            
            Thread.Sleep(1000);

            Console.WriteLine("1. Rad s podacima o radnicima ");
            Console.WriteLine("2. Rad s obračunima ");
            Console.WriteLine("3. Rad s plačama ");
            Console.WriteLine("4. Izlaz iz programa ");

            OdabirGlavniIzborniki();

        }

        public void OdabirGlavniIzborniki()
        {
            switch (Pomocno.UcitajRasponBrojeva("Odaberite broj između između 1-4 za rad s glavnim izbornikom: ", "Odabreni broj mora biti između 1-4 ", 1, 4))
            {
                case 1:
                    ObradaRadnici.PrikaziIzbornik();
                    GlavniIzbornikSucelje();
                    break;
                case 2:
                    ObradaObracuni.PrikaziIzbornik();
                    GlavniIzbornikSucelje();
                    break;
                case 3:
                    ObradaPlace.PrikaziIzbornik();
                    GlavniIzbornikSucelje();
                    break;
                case 4:
                    Thread.Sleep(1000);
                    Console.WriteLine("******************************************");
                    Console.WriteLine("Hvala na korištenju aplikaije. Doviđenja!!");
                    Console.WriteLine("******************************************");
                    break;

            }
        }

    }
}

