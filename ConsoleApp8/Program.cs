using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Operatorok
{
    class Program
    {
        public static string Szamol(string bemenet)
        {
            string kimenet = "";
            string[] splitelt = bemenet.Split(' ');
            if (splitelt[1] == "+" || splitelt[1] == "-" || splitelt[1] == "*" || splitelt[1] == "/" || splitelt[1] == "mod" || splitelt[1] == "div")
            {
                try
                {
                    int elso = Convert.ToInt32(splitelt[0]);
                    int maso = Convert.ToInt32(splitelt[2]);
                    if (splitelt[1] == "+")
                    {
                        int ered = elso + maso;
                        return ered.ToString();
                    }
                    else
                        if (splitelt[1] == "mod")
                    {
                        int ered = elso % maso;
                        return ered.ToString();
                    }

                }
                catch (Exception)
                {
                    kimenet = "Egyéb hiba";

                }
            }
            else
            {
                kimenet = "Hibás operátor";
            }

            return kimenet;

        }
        static void Main(string[] args)
        {
            string[] fajl = File.ReadAllLines("kifejezesek.txt");

            Console.WriteLine("2.feladat:" + fajl.Length);
            int modDb = 0;
            for (int i = 0; i < fajl.Length; i++)
            {
                string[] splitelt = fajl[i].Split(' ');
                if (splitelt[1] == "mod")
                {
                    modDb++;
                }
            }
            Console.WriteLine("3.feladat:" + modDb);

            //4
            bool maradekNelkül = false;
            for (int i = 0; i < fajl.Length; i++)
            {
                string[] splitelt = fajl[i].Split(' ');
                if (Convert.ToInt32(splitelt[0]) % 10 == 0 && Convert.ToInt32(splitelt[2]) % 10 == 0)
                {
                    maradekNelkül = true;
                    break;
                }
            }
            if (maradekNelkül == true)
            {
                Console.WriteLine("4.feladat: Van ilyen kifejezés!");
            }
            else
            {
                Console.WriteLine("4.feladat: Nincs ilyen kifejezés!");
            }

            //5
            int dbPlussz = 0;
            int dbMinusz = 0;
            int dbSzor = 0;
            int dbOszt = 0;
            int dbMod = 0;
            int dbDiv = 0;
            for (int i = 0; i < fajl.Length; i++)
            {
                string[] splitelt = fajl[i].Split(' ');
                if (splitelt[1] == "+")
                {
                    dbPlussz++;

                }
                else if (splitelt[1] == "-")
                {
                    dbMinusz++;
                }
                else if (splitelt[1] == "*")
                {
                    dbSzor++;
                }
                else if (splitelt[1] == "/")
                {
                    dbOszt++;
                }
                else if (splitelt[1] == "mod")
                {
                    dbMod++;
                }
                else if (splitelt[1] == "div")
                {
                    dbDiv++;
                }
            }
            Console.WriteLine("5.feladat: ");
            Console.WriteLine("\t + -> " + dbPlussz + " db");
            Console.WriteLine("\t - -> " + dbMinusz + " db");
            Console.WriteLine("\t * -> " + dbSzor + " db");
            Console.WriteLine("\t / -> " + dbOszt + " db");
            Console.WriteLine("\t mod -> " + dbMod + " db");
            Console.WriteLine("\t div -> " + dbDiv + " db");


            //6.
            Console.WriteLine(Szamol("6 mod 2"));

            //7.


            //8.
            List<string> kiir = new List<string>();
            for (int i = 0; i < fajl.Length; i++)
            {
                kiir.Add(Szamol(fajl[i]));
            }
            File.WriteAllLines("eredmenyek.txt", kiir);

            Console.ReadKey();
        }
    }
}