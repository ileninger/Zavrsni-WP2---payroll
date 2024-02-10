using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavršniRad.KonzolnaAplikacija
{
    internal class Pomocno
    {
        public static bool Test;
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

        internal static DateTime UcitajDatum(string poruka, string greska)
        {
            while (true)
            {
                try
                {
                    Console.Write(poruka);
                    return DateTime.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }
        }

        public static bool ProvjeriOiB(string oib)
        {
            if (oib.Length != 11)
            {
                Console.WriteLine("**********************************");
                Console.WriteLine("OIB mora imati 11 znamenki.");
                return false;
            }

            long b;
            if (!long.TryParse(oib, out b))
            {
                Console.WriteLine("**********************************");

                Console.WriteLine("OIB mora sadržavati samo brojeve.");
                return false;
            }

            int a = 10;
            for (int i = 0; i < 10; i++)
            {
                a = a + int.Parse(oib.Substring(i, 1));
                a = a % 10;
                if (a == 0)
                {
                    a = 10;
                }
                a *= 2;
                a = a % 11;
            }

            int kontrolniBroj = 11 - a;
            if (kontrolniBroj == 10) kontrolniBroj = 0;

            return kontrolniBroj == int.Parse(oib.Substring(10, 1));
        }
    }
}
