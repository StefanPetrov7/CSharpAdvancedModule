using System;
using System.Linq;

namespace Parking_System
{
    class Program
    {
        internal class Car
        {
            public Car(int row, int col)
            {
                this.Row = row;
                this.Col = col;
                this.Distance = 1;
            }

            public int Row { get; set; }
            public int Col { get; set; }
            public int RowEnd { get; set; }
            public int ColEnd { get; set; }
            public int Distance { get; set; }
            public bool EmptyLeftFound { get; set; }
            public bool EmptyRightFound { get; set; }
            public int ExtraLeft { get; set; }
            public int ExtraRight { get; set; }
        }

        static void Main(string[] args)
        {
            const string FINISH_INPUT = "stop";
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[size[0], size[1]];

            string input;

            while ((input = Console.ReadLine()) != FINISH_INPUT)
            {
                int[] info = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                Car car = new Car(info[0], 0);
                car.RowEnd = info[1];
                car.ColEnd = info[2];

                if (VerifyInput(matrix, car))
                {
                    if (CarTryToPark(matrix, car))
                    {
                        Console.WriteLine(car.Distance);
                    }
                    else
                    {
                        Console.WriteLine($"Row {car.RowEnd} full");
                    }
                }
            }
        }

        private static bool CarTryToPark(int[,] matrix, Car car)
        {
            if (car.Row > car.RowEnd)
            {
                while (car.Row > car.RowEnd)
                {
                    car.Row--;
                    car.Distance++;
                }
            }
            else if (car.Row < car.RowEnd)
            {
                while (car.Row < car.RowEnd)
                {
                    car.Row++;
                    car.Distance++;
                }
            }

            while (car.Col < car.ColEnd)
            {
                car.Col++;
                car.Distance++;
            }

            if (matrix[car.Row, car.Col] == 0)
            {
                matrix[car.Row, car.Col] = 1;
                return true;
            }
            else
            {
                while (car.Col > 1)
                {
                    car.Col--;
                    car.ExtraLeft++;

                    if (matrix[car.Row, car.Col] == 0)
                    {
                        car.EmptyLeftFound = true;
                        break;
                    }
                }

                car.Col += car.ExtraLeft;

                while (car.Col < matrix.GetLength(1) - 1)
                {
                    car.Col++;
                    car.ExtraRight++;

                    if (matrix[car.Row, car.Col] == 0)
                    {
                        car.EmptyRightFound = true;
                        break;
                    }
                }

                car.Col -= car.ExtraRight;

                if (car.EmptyLeftFound == true && car.EmptyRightFound == true)
                {

                    if (car.ExtraLeft < car.ExtraRight)
                    {
                        car.Col -= car.ExtraLeft;
                        car.Distance -= car.ExtraLeft;
                        matrix[car.Row, car.Col] = 1;
                    }
                    else if (car.ExtraRight < car.ExtraLeft)
                    {
                        car.Col += car.ExtraRight;
                        car.Distance += car.ExtraRight;
                        matrix[car.Row, car.Col] = 1;
                    }
                    else
                    {
                        car.Col -= car.ExtraLeft;
                        car.Distance -= car.ExtraLeft;
                        matrix[car.Row, car.Col] = 1;
                    }

                    return true;
                }
                else if (car.EmptyLeftFound == true)
                {
                    car.Col -= car.ExtraLeft;
                    car.Distance -= car.ExtraLeft;
                    matrix[car.Row, car.Col] = 1;
                    return true;
                }
                else if (car.EmptyRightFound == true)
                {
                    car.Col += car.ExtraRight;
                    car.Distance += car.ExtraRight;
                    matrix[car.Row, car.Col] = 1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static bool VerifyInput(int[,] matrix, Car car)
        {

            if (car.RowEnd < 0 || car.RowEnd > matrix.GetLength(0) - 1
                || car.ColEnd < 0 || car.ColEnd > matrix.GetLength(1) - 1)
            {
                return false;
            }

            return true;
        }
    }
}
