using System;

namespace Revolt
{
    class Program
    {
        public class Point
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public bool Finish { get; set; } = false;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int cmdCount = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            Point point = new Point();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] rowInfo = Console.ReadLine().ToCharArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowInfo[c];

                    if (matrix[r, c] == 'f')
                    {
                        matrix[r, c] = '-';
                        point.Row = r;
                        point.Col = c;

                    }
                }
            }

            for (int i = 0; i < cmdCount; i++)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "up":
                        MoveUp(point, matrix);
                        break;
                    case "down":
                        MoveDown(point, matrix);
                        break;
                    case "right":
                        MoveRight(point, matrix);
                        break;
                    case "left":
                        MoveLeft(point, matrix);
                        break;
                }

                if (point.Finish == true)
                {
                    break;
                }
            }

            string result = point.Finish ? "Player won!" : "Player lost!";
            matrix[point.Row, point.Col] = 'f';
            Console.WriteLine(result);
            PrintMatrix(matrix);
        }

        private static void MoveLeft(Point point, char[,] matrix)
        {
            point.Col -= 1;
            CheckPossitionIfOut(point, matrix);

            if (matrix[point.Row, point.Col] == 'B')
            {
                point.Col -= 1;
                CheckPossitionIfOut(point, matrix);
            }

            if (matrix[point.Row, point.Col] == 'T')
            {
                point.Col += 1;
                CheckPossitionIfOut(point, matrix);
            }

            IsFinished(point, matrix);
        }

        private static void MoveRight(Point point, char[,] matrix)
        {
            point.Col += 1;
            CheckPossitionIfOut(point, matrix);

            if (matrix[point.Row, point.Col] == 'B')
            {
                point.Col += 1;
                CheckPossitionIfOut(point, matrix);
            }

            if (matrix[point.Row, point.Col] == 'T')
            {
                point.Col -= 1;
                CheckPossitionIfOut(point, matrix);
            }

            IsFinished(point, matrix);
        }

        private static void MoveDown(Point point, char[,] matrix)
        {
            point.Row += 1;

            CheckPossitionIfOut(point, matrix);

            if (matrix[point.Row, point.Col] == 'B')
            {
                point.Row += 1;
                CheckPossitionIfOut(point, matrix);
            }

            if (matrix[point.Row, point.Col] == 'T')
            {
                point.Row -= 1;
                CheckPossitionIfOut(point, matrix);
            }

            IsFinished(point, matrix);
        }


        private static void MoveUp(Point point, char[,] matrix)
        {
            point.Row -= 1;

            CheckPossitionIfOut(point, matrix);

            if (matrix[point.Row, point.Col] == 'B')
            {
                point.Row -= 1;
                CheckPossitionIfOut(point, matrix);
            }

            if (matrix[point.Row, point.Col] == 'T')
            {
                point.Row += 1;
                CheckPossitionIfOut(point, matrix);
            }

            IsFinished(point, matrix);
        }

        private static void CheckPossitionIfOut(Point point, char[,] matrix)
        {
            if (point.Row < 0)
            {
                point.Row = matrix.GetLength(0) - 1;
            }
            else if (point.Row > matrix.GetLength(0) - 1)
            {
                point.Row = 0;
            }
            else if (point.Col < 0)
            {
                point.Col = matrix.GetLength(1) - 1;
            }
            else if (point.Col > matrix.GetLength(1) - 1)
            {
                point.Col = 0;
            }
        }

        private static void IsFinished(Point point, char[,] matrix)
        {
            if (matrix[point.Row, point.Col] == 'F')
            {
                point.Finish = true;
            }
        }

        private static void PrintMatrix(char[,] matrix)
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
    }
}
