using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad.KonzolnaAplikacijaUjednojKlasi
{
    internal class Pomocno
    {
        public static int UcitajRasponBrojeva(string poruka, string greska, int poc, int kraj)
        {
            int i;
            while (true)
            {
                Console.Write(poruka);

                try
                {
                    i = int.Parse(Console.ReadLine());
                    if (i >= poc && i <= kraj)
                    {
                        return i;
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }

        }
    }
}
