﻿using System;
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
                    PrikaziIzbornik();
                    break;
                case 2:
                    DodajPlacu();
                    PrikaziIzbornik();
                    break;
                case 3:
                    UrediPodatkeOPlaci();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiPlacu();
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
            var i = 0;

            Place.ForEach(s =>
            {
                Console.WriteLine(++i + "." + s);
            });

            Console.WriteLine("///////////////////////////////////////////////"); ;
        }

        private void DodajPlacu()
        {
            var p = new Placa();

            p.Sifra = Pomocno.UcitajCijeliBroj("Unesite šifru plaće: ", "Šifra plaće mora biti pozivni cijeli broj");
            p.NazivPlace = Pomocno.UcitajString("Unesite naziv plaće: ", "Naziv plaće je obavezan ");

            p.Obracun = DodijelaObracunPlaci();

            Place.Add(p);

        }
        private List<Obracun> DodijeliObracunePlaci()
        {
            List<Obracun> obracun = new List<Obracun>();
            obracun.Add(DodijelaObracunPlaci());
            return obracun;
        }
        private Obracun DodijelaObracunPlaci()
        {
            GlavniIzbornik.ObradaObracuni.PrikaziSveObracune();

            int index = Pomocno.UcitajRasponBrojeva("Odaberi redni broj obračuna: ", "Nije dobar odabir", 1, GlavniIzbornik.ObradaObracuni.Obracuni.Count());

            return GlavniIzbornik.ObradaObracuni.Obracuni[index - 1];

        }

        private void UrediPodatkeOPlaci()
        {
            if (Place.Count != 0)
            {
                PrikaziSvePlace();
                int index = Pomocno.UcitajRasponBrojeva("Odaberi redni broj obračuna: ", "Nije dobar odabir", 1, Place.Count());
                var placa = Place[index - 1];

                Console.WriteLine("1.Izmjeni šifru plaće ");
                Console.WriteLine("2.Izmeni naziv plaće ");
                Console.WriteLine("3.Izmjeni dojeljeni obračun ");
                Console.WriteLine("4.Odustanite od promjena podataka o plačama");


                switch (Pomocno.UcitajRasponBrojeva("Odaberite broj između između 1-7 za rad s izbornikom promjena podataka o radniku: ", "Odabreni broj mora biti između 1-7 ", 1, 7))
                {
                    case 1:
                        placa.Sifra = Pomocno.UcitajCijeliBroj("Unesite šifru radnika ", "Šifra radnika mora biti pozivni cijeli broj");
                        PrikaziSvePlace();
                        break;
                    case 2:
                        placa.NazivPlace = Pomocno.UcitajString("Unesite novi naziv plaće ", "Naziv plaće je obavezan ");
                        PrikaziSvePlace();
                        break;
                    case 3:
                        placa.Obracun = DodijelaObracunPlaci();
                        PrikaziSvePlace();
                        break;
                    case 4:
                        Console.WriteLine("Završili ste s radom na plačama! Slijedi povratak na izbornik! ");
                        Thread.Sleep(1000);
                        PrikaziIzbornik();
                        break;

                }

            }
            else
            {
                Console.WriteLine("Prvo morate unjeti plaču kako biste mogli promljeniti podatke o plaći ");
                if (Pomocno.UcitajBool("Želite li dodati plaču? (da ili bilo što drugo za ne): "))
                {
                    DodajPlacu();
                }
                else
                {
                    Console.WriteLine("Slijedi povratak na glavni izbornik rada s plačama ");
                    Thread.Sleep(1000);
                    PrikaziIzbornik();
                }
            }
        }

        private void ObrisiPlacu()
        {
            PrikaziSvePlace();
            int index = Pomocno.UcitajRasponBrojeva("Odaberi redni broj obračuna: ", "Nije dobar odabir", 1, Place.Count());
            Place.RemoveAt(index - 1);

        }
    }
}
