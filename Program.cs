using System;
using System.Runtime.Serialization;
using System.Text;
namespace SnakeMangV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Title = "Madu mäng"; // Seadistab konsooliakna pealkirja "Maomäng"

            Menu menu = new Menu();
            menu.Show(); // Helista menüü kuvamiseks meetodile Näita

            Console.ResetColor(); // Asetab konsooli esiplaani ja taustavärvid nende vaikeväärtustele
        }
    }
}