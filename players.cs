using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMangV2
{
    internal class players
    {
        private string _failiTee = @"..\..\..\tulemus.txt"; // Tee faili juurde

        public players() { }

        // Lisab tekstifaili mängija nime, skoori ja taseme
        public void Salvesta_faili(string nimi, int punktid, string level)
        {
            try
            {
                // Avage uus StreamWriter, et lisada faili lõppu
                using (StreamWriter sw = new StreamWriter(_failiTee, true))
                {
                    sw.WriteLine($"{nimi}: {punktid} punktid, Tasemel: {level}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // Loeb ja kuvab tekstifaili sisu
        public void Naitab_faili()
        {
            try
            {
                // Failist lugemiseks avage StreamReader
                using (StreamReader sr = new StreamReader(_failiTee))
                {
                    // Loe kogu faili sisu stringiks
                    string lines = sr.ReadToEnd();
                    Console.WriteLine(lines);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
