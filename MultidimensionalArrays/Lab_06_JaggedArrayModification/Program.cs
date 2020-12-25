using System;
using System.Linq;

namespace Lab_06_JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matriX = new int[n][];

            for (int r = 0; r < matriX.Length; r++)
            {
                int[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matriX[r] = new int[rowData.Length];

                for (int c = 0; c < rowData.Length; c++)
                {
                    matriX[r][c] = rowData[c];
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();
                string command = cmd[0];
                int r = int.Parse(cmd[1]);
                int c = int.Parse(cmd[2]);
                int num = int.Parse(cmd[3]);

                if ((r < 0 || r >= matriX.Length))
                {
                    Console.WriteLine($"Invalid coordinates");
                }
                else if (c < 0 || c >= matriX[r].Length)
                {
                    Console.WriteLine($"Invalid coordinates");
                }
                else
                {
                    switch (command)
                    {
                        case "Add":
                            matriX[r][c] += num;
                            break;

                        case "Subtract":
                            matriX[r][c] -= num;
                            break;
                    }
                }
            }

            foreach (var item in matriX)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
