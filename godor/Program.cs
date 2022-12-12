using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace godor
{
    class Program
    {
        static List<int> melysegek = new List<int>();
        static int tavolsag;
        static int godrokSzama = 0;
        static void Main(string[] args)
        {
            ElsoFeladat();
            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();

            Console.ReadKey();
        }

        private static void HatodikFeladat()
        {
            Console.WriteLine("\n6. feladat");
            Console.WriteLine("a)");
            int kezdet = 0;
            int veg = 0;
            for (int i = 0; i < melysegek.Count; i++)
            {
                if (melysegek[i] != 0 && kezdet == 0)
                {
                    kezdet = i + 1;
                }
                if (kezdet != 0 && veg == 0 && melysegek[i + 1] == 0)
                {
                    veg = i + 1;
                    break;
                }
            }

            Console.WriteLine("A gödör kezdete: " + kezdet + " méter, a gödör vége: " + veg + " méter.");
        }

        private static void OtodikFeladat()
        {
            Console.WriteLine("\n5. feladat");
            Console.WriteLine("A gödrök száma: " + godrokSzama);
        }

        private static void NegyedikFeladat()
        {
            using (StreamWriter sw = new StreamWriter("godrok.txt"))
            {
                int elozoSzam = 0;
                foreach (int godor in melysegek)
                {
                    if (godor != 0)
                    {
                        sw.Write(godor + " ");
                        elozoSzam = godor;
                    } 
                    else if (elozoSzam != 0)
                    {
                        sw.WriteLine();
                        elozoSzam = godor;
                        godrokSzama++;
                    }
                }
            }
        }

        private static void HarmadikFeladat()
        {
            Console.WriteLine("\n3. feladat");
            Console.WriteLine("Az érintetlen terület aránya " + Math.Round((double)melysegek.Count(x => x == 0) / melysegek.Count() * 100, 2) + "%");
        }

        private static void MasodikFeladat()
        {
            Console.WriteLine("\n2. feladat");
            Console.Write("Adjon meg egy távolságértéket! ");
            tavolsag = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ezen a helyen a felszín " + melysegek[tavolsag] + " méter mélyen van.");
        }

        private static void ElsoFeladat()
        {
            Console.WriteLine("1. feladat");

            using (StreamReader sr = new StreamReader("melyseg.txt"))
            {
                while (!sr.EndOfStream)
                {
                    melysegek.Add(Convert.ToInt32(sr.ReadLine()));
                }
            }

            Console.WriteLine("A fájl adatainak száma: " + melysegek.Count);
        }
    }
}
