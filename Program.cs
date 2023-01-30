using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 30;
            int height = 15;

            int foodX = width / 2;
            int foodY = height / 2;

            List<(int, int)> snake = new List<(int, int)>
            {
                (width / 2, height / 2),
                (width / 2 - 1, height / 2),
                (width / 2 - 2, height / 2)
            };

            ConsoleKey key = ConsoleKey.RightArrow;

            while (true)
            {
                Console.Clear();

                for (int i = 0; i < width; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();

                for (int y = 0; y < height; y++)
                {
                    Console.Write("|");
                    for (int x = 0; x < width - 2; x++)
                    {
                        if (foodX == x && foodY == y)
                        {
                            Console.Write("+");
                        }
                        else if (snake.Contains((x, y)))
                        {
                            Console.Write("=");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine("|");
                }

                for (int i = 0; i < width; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();

                (int headX, int headY) = snake[^1];

                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        headX++;
                        break;
                    case ConsoleKey.LeftArrow:
                        headX--;
                        break;
                    case ConsoleKey.UpArrow:
                        headY--;
                        break;
                    case ConsoleKey.DownArrow:
                        headY++;
                        break;
                }

                if (headX == foodX && headY == foodY)
                {
                    snake.Add((headX, headY));
                    foodX = new Random().Next(1, width - 2);
                    foodY = new Random().Next(1, height - 2);
                }
                else
                {
                    snake.RemoveAt(0);
                    snake.Add((headX, headY));
                }

                if (headX == 0 || headX == width - 1 || headY == 0 || headY == height - 1)
                {
                    Console.WriteLine("Game Over");
                    break;
                }

                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true).Key;
                }

                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
