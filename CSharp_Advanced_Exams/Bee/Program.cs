using System;
using System.Collections.Generic;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            int[] bee = new int[2];

            for (int r = 0; r < field.GetLength(0); r++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int c = 0; c < field.GetLength(1); c++)
                {
                    field[r, c] = rowData[c];

                    if (field[r, c] == 'B')
                    {
                        bee[0] = r;
                        bee[1] = c;
                    }
                }
            }

            int[] pollinatedFlowers = new int[1];
            Stack<string> commands = new Stack<string>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                field[bee[0], bee[1]] = '.';
                commands.Push(input);

                switch (input)
                {
                    case "up":
                        bee[0] -= 1;
                        break;
                    case "down":
                        bee[0] += 1;
                        break;
                    case "left":
                        bee[1] -= 1;
                        break;
                    case "right":
                        bee[1] += 1;
                        break;
                }

                if (bee[0] < 0 || bee[0] > field.GetLength(0) - 1 || bee[1] < 0 || bee[1] > field.GetLength(1) - 1)
                {
                    Console.WriteLine($"The bee got lost!");
                    break;
                }

                if (field[bee[0], bee[1]] == 'O')
                {
                    field[bee[0], bee[1]] = '.';
                    switch (commands.Pop())
                    {
                        case "up":
                            bee[0] -= 1;
                            break;
                        case "down":
                            bee[0] += 1;
                            break;
                        case "left":
                            bee[1] -= 1;
                            break;
                        case "right":
                            bee[1] += 1;
                            break;
                    }
                }

                if (field[bee[0], bee[1]] == 'f')
                {
                    pollinatedFlowers[0] += 1;
                }
                field[bee[0], bee[1]] = 'B';
            }

            if (pollinatedFlowers[0] >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers[0]} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers[0]} flowers more");
            }

            PrintMatrix(field);
        }

        public static void PrintMatrix(char[,] field)
        {
            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    Console.Write(field[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
