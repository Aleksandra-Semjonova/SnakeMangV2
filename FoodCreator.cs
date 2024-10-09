using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMangV2
{
    // Klass toidu loomiseks ja mis loob toitu randomsele kohale
    internal class FoodCreator
    {
        private int mapWidth;
        private int mapHeight;
        private List<NewFood> foodItems;

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;

            // erinevad toit koos sümbolite ja punktidega
            foodItems = new List<NewFood>
            {
                new NewFood('$', 1),  // 1+
                new NewFood('*', 2),  // 2+
                new NewFood('@', 3)   // 3+
            };
        }

        public List<(Point, int)> CreateFoods(int count)
        {
            var foods = new List<(Point, int)>();

            for (int i = 0; i < count; i++)
            {
                int x = random.Next(2, mapWidth - 2);
                int y = random.Next(2, mapHeight - 1);
                var foodItem = foodItems[random.Next(foodItems.Count)];

                foods.Add((new Point(x, y, foodItem.Symbol), foodItem.Points));
            }

            return foods;
        }
    }
}
