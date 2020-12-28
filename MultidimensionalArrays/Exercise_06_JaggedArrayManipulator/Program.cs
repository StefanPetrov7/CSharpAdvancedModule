using System;
using System.Linq;

namespace Exercise_06_JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];

            for (int r = 0; r < matrix.Length; r++)
            {
                int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                matrix[r] = new int[data.Length];

                for (int c = 0; c < data.Length; c++)
                {
                    matrix[r][c] = data[c];
                }

                if ((r > 0) && (matrix[r].Length == matrix[r - 1].Length))
                {
                    matrix[r - 1] = matrix[r - 1].Select(x => x * 2).ToArray();
                    matrix[r] = matrix[r].Select(x => x * 2).ToArray();

                }
                else if ((r > 0) && (matrix[r].Length != matrix[r - 1].Length))
                {
                    matrix[r - 1] = matrix[r - 1].Select(x => x / 2).ToArray();
                    matrix[r] = matrix[r].Select(x => x / 2).ToArray();
                }
            }

            if (n==1)
            {
                matrix[0] = matrix[0].Select(x => x / 2).ToArray();
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int ellRow = int.Parse(cmd[1]);
                int ellCol = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);

                switch (cmd[0])
                {
                    case "Add":
                        if ((ellRow >= 0 && ellRow < matrix.Length)
                            && (ellCol >= 0 && ellCol < matrix[ellRow].Length))
                        {
                            matrix[ellRow][ellCol] += value;
                        }
                        break;

                    case "Subtract":
                        if ((ellRow >= 0 && ellRow < matrix.Length)
                         && (ellCol >= 0 && ellCol < matrix[ellRow].Length))
                        {
                            matrix[ellRow][ellCol] -= value;
                        }
                        break;

                }

            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }
    }
}
