using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMangV2
{
    internal class Menu
    {
        public void Show()
        {
            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        ChooseLevel();
                        break;
                    case "2":
                        ShowScores();
                        break;
                    case "3":
                        Console.WriteLine("Välju mängust!");

                        return;
                    default:
                        Console.WriteLine("Vale valik. Palun proovi uuesti.");
                        break;
                }
            }
        }

        private void DisplayMenu()
        {


            Console.Clear();
            Console.WriteLine("Tere tulemast mängu Snake!");
            Console.WriteLine("1. Mängi");
            Console.WriteLine("2. Näita tulemusi");
            Console.WriteLine("3. Välja tulla");
            Console.Write("Sisesta oma valik: ");
        }

        private void ChooseLevel()
        {
            Console.Clear();
            Console.WriteLine("Valige mängimiseks tase");
            Console.WriteLine("1. Lihtne");
            Console.WriteLine("2. Keskmine");
            Console.WriteLine("3. Kõva");
            Console.Write("Sisesta oma valik: ");

            string levelChoice = Console.ReadLine();
            BaseLevel level;
            string levelName;

            switch (levelChoice)
            {
                case "1":
                    level = new EasyLevel();
                    levelName = "Lihtne";
                    break;
                case "2":
                    level = new MediumLevel();
                    levelName = "Keskmine";
                    break;
                case "3":
                    level = new HardLevel();
                    levelName = "Raske";
                    break;
                default:
                    Console.WriteLine("Vale valik.");
                    return;
            }







            int score = level.PlayLevel();

            SaveScore(score, level.Name);
        }



        private void SaveScore(int score, string levelName)
        {
            Console.WriteLine("!!! Mäng läbi!!! Sisesta oma mängu nimi:");
            string name = Console.ReadLine();
            players mängijad = new players();
            // Сохраняем счет, имя игрока и название уровня в файл
            mängijad.Salvesta_faili(name, score, levelName);
            Console.WriteLine("Mänguandmed on salvestatud...");
            Console.ReadKey();

        }

        private void ShowScores()
        {

            players mängijad = new players();
            Console.Clear();
            Console.WriteLine("Tulemused:");
            // meetod, kuidas kuvada failist saadud hindeid
            mängijad.Naitab_faili();
            Console.WriteLine("Vajutage suvalist võtit, et menüüsse naasta...");
            Console.ReadKey();

        }
    }
}
