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
        
        public static int UcitajCijeliBroj(string poruka, string greska)
        {
            int i;
            while (true)
            {
                Console.Write(poruka);
                try
                {
                    i = int.Parse(Console.ReadLine());
                    if (i > 0)
                    {
                        return i;
                    }
                    Console.WriteLine(greska);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }
        }

        public static decimal UcitajDecimalnibroj (string poruka, string greska)
        {
            decimal i;
            {
                while (true)
                {
                    Console.Write(poruka);
                    try
                    {
                        i = decimal.Parse(Console.ReadLine());
                        if (i > 0)
                        {
                            return i;
                        }
                        Console.WriteLine(greska);
                    }
                    catch (Exception ex)
                    { 
                        Console.WriteLine(greska);
                    }
                }
            }
        }

        public static string UcitajString (string poruka, string greska)
        {
            string s = "";

            while (true)
            {
                Console.Write(poruka);
                s=Console.ReadLine();
                if(s != null && s.Trim().Length > 0)
                {
                    return s;

                }
                Console.WriteLine(greska);
            }
        }

        internal static DateOnly UcitajDatum(string poruka, string greska)
        {
            while (true)
            {
                Console.Write(poruka);
                try
                {
                   return DateOnly.Parse(Console.ReadLine());   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }
        } 
    }
}
