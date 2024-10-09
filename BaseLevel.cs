using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMangV2
{
    //
    internal abstract class BaseLevel
    {

        //Абстрактные свойства класса 
        public abstract string Name { get; }
        public abstract ConsoleColor Color { get; }
        public abstract int Speed { get; }
        public abstract int Width { get; }
        public abstract int Height { get; }

        //Эти свойства абстрактны, то есть конкретные значения для них должны быть определены в подклассах(например, в разных уровнях игры).
        public int PlayLevel()
        {
            Console.Clear();
            Console.ForegroundColor = Color;
            Console.WriteLine($"Lähtetase: {Name}");

            //Отрисовка стен и змейки:
            Walls walls = new Walls(Width, Height);
            walls.Draw();

            Point p = new Point(4, 5, '#');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();


            FoodCreator foodCreator = new FoodCreator(Width, Height);
            List<(Point food, int points)> foods = foodCreator.CreateFoods(3);

            foreach (var (food, points) in foods)
            {
                food.Draw();
            }

            int score = 0;

            DisplayScore(score, Width + 5, 2);

            while (true)
            {
                if (walls.isHit(snake) || snake.isHitTail())
                {

                    break;
                }

                for (int i = 0; i < foods.Count; i++)
                {
                    if (snake.Eat(foods[i].food))
                    {
                        score += foods[i].points; //Добавляйте баллы за еду, которую вы едите
                        foods.RemoveAt(i); // Удаляем съеденную еду из списка
                        foods.Add(foodCreator.CreateFoods(1)[0]); // Создага новая еда
                        foods[foods.Count - 1].food.Draw(); // показывает новую еду



                        DisplayScore(score, Width + 5, 2);

                        break;
                    }
                }
                //Движение змейки и управление
                snake.Move();

                Thread.Sleep(Speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            //Конец игры
            Console.SetCursorPosition(0, Height + 2);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"You scored: {score}.");

            return score;
        }


        private void DisplayScore(int score, int x, int y)
        {
            Console.SetCursorPosition(x, y); // Määra kursori asend väljaspool mänguala
            Console.ForegroundColor = Color; // Määra hindeteksti värv
            Console.Write($"Score: {score}  ");
        }

    }
}
