using System.Linq;

namespace Fishing_Competition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string END_PROGRAM = "collect the nets";

            int n = int.Parse(Console.ReadLine());
            Ship ship = new Ship();
            string[,] matrix = CreateMatrix(n, ref ship);

            string input;

            while ((input = Console.ReadLine()) != END_PROGRAM)
            {
                string cmd = input;
                matrix[ship.Row, ship.Col] = "-";

                switch (cmd)
                {
                    case "up":
                        ship.Row--;
                        break;
                    case "down":
                        ship.Row++;
                        break;
                    case "right":
                        ship.Col++;
                        break;
                    case "left":
                        ship.Col--;
                        break;
                }

                VerifyPossition(matrix, ship);
                InspectPossition(matrix, ship);
                matrix[ship.Row, ship.Col] = "S";

                if (ship.Sank == true)
                {
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. " +
                        $"Last coordinates of the ship: [{ship.Row},{ship.Col}]");
                    Environment.Exit(0);
                }
            }


            if (ship.FishCought >= 20)
            {
                Console.WriteLine("Success! You managed to reach the quota!");
            }
            else
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - ship.FishCought} tons of fish more.");
            }

            if (ship.FishCought > 0)
            {
                Console.WriteLine($"Amount of fish caught: {ship.FishCought} tons.");
            }

            WriteMatrix(matrix);
        }

        private static void InspectPossition(string[,] matrix, Ship ship)
        {
            int row = ship.Row;
            int col = ship.Col;

            if (matrix[row, col] == "W")
            {
                ship.Sank = true;
                return;
            }

            if (Char.IsNumber(char.Parse(matrix[row, col])))
            {
                ship.FishCought += int.Parse(matrix[row, col]);
                return;
            }

        }

        private static void VerifyPossition(string[,] matrix, Ship ship)
        {
            int row = ship.Row;
            int col = ship.Col;

            if (row > matrix.GetLength(0) - 1)
            {
                row = 0;
            }

            if (row < 0)
            {
                row = matrix.GetLength(0) - 1;
            }

            if (col > matrix.GetLength(1) - 1)
            {
                col = 0;
            }

            if (col < 0)
            {
                col = matrix.GetLength(1) - 1;
            }

            ship.Row = row;
            ship.Col = col;
        }

        private static string[,] CreateMatrix(int n, ref Ship ship)
        {
            string[,] matrix = new string[n, n];

            for (int r = 0; r < n; r++)
            {
                string rowData = Console.ReadLine();

                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = rowData.Substring(c, 1);

                    if (matrix[r, c] == "S")
                    {
                        ship.Row = r;
                        ship.Col = c;
                    }
                }
            }

            return matrix;
        }

        private static void WriteMatrix(string[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }

                Console.WriteLine();
            }
        }

        public class Ship
        {
            public Ship()
            {
                this.Sank = false;
            }

            public int Row { get; set; }

            public int Col { get; set; }

            public bool Sank { get; set; }

            public int FishCought { get; set; }

        }
    }
}