using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static readonly int x = 76;
        static readonly int y = 26;
        static Food food;
        static Snake snake;
        static Timer timer;
        static Walls walls;


        static void Main(string[] args)
        {
            Console.SetWindowSize(x + 1, y + 1);        //Console set up
            Console.SetBufferSize(x + 1, y + 1);
            Console.CursorVisible = false;

            walls = new Walls(x, y, '#');

            snake = new Snake(x / 2, y / 2, 3);

            food = new Food(x, y, '@');
            food.CreateFood();

            timer = new Timer(Loop, null, 0, 200);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.Rotation(key.Key);
                }
            }
        }

        static void Loop(object obj)
        {
            if (walls.IsHit(snake.GetHead()) || snake.IsHit(snake.GetHead()))
            {
                timer.Change(0, Timeout.Infinite);
            }
            else if (snake.Eat(food.food))
            {
                food.CreateFood();
            }
            else
            {
                snake.Move();
            }

        }


    }
}
