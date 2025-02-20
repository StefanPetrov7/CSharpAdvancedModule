namespace ExamJune22
{
    internal class Beesy
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] bee = new int[6];   // bee[0] row => bee[1]  col
            bee[2] = 15;  // Energy 
            bee[3] = 0;   // Nectar Collected
            bee[4] = 0;   // Times run out of energy => 0 = false 
            bee[5] = 0;   // Hive reached == 1

            int minNectarNeeded = 30;

            char[,] hive = ReadMatrix(n, bee);

            string cmd = string.Empty;

            while ((cmd = Console.ReadLine()) != string.Empty)
            {
                if (bee[5] == 1) break;

                if (!HasEnergy(bee)) break;

                MoveBee(hive, cmd, bee);

            }

            if (bee[5] == 1 && bee[3] >= minNectarNeeded)
            {
                Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {bee[2]}");
            }
            else if (bee[5] == 1 && bee[3] < minNectarNeeded)
            {
                Console.WriteLine("Beesy did not manage to collect enough nectar.");
            }
            else
            {
                Console.WriteLine("This is the end! Beesy ran out of energy.");
            }

            WriteMatrix(hive, x => Console.Write(x));
        }

        public static void MoveBee(char[,] hive, string move, int[] bee)
        {
            Direction direction = (Direction)Enum.Parse(typeof(Direction), move);   
            bee[2]--;
            hive[bee[0], bee[1]] = '-';

            switch (direction)
            {
                case Direction.up:
                    bee[0]--;
                    break;
                case Direction.down:
                    bee[0]++;
                    break;
                case Direction.right:
                    bee[1]++;
                    break;
                case Direction.left:
                    bee[1]--;
                    break;

            }

            CheckIfBeeIsInHive(hive, bee);

            if (Char.IsDigit(hive[bee[0], bee[1]]))
            {
                bee[3] += int.Parse(hive[bee[0], bee[1]].ToString());
            }

            if (hive[bee[0], bee[1]] == 'H')
            {
                bee[5] = 1;
            }

            hive[bee[0], bee[1]] = 'B';

            CheckEnergy(bee);
        }

        public static bool HasEnergy(int[] bee) => bee[2] > 0;

        public static void CheckEnergy(int[] bee)  // To be Continued
        {
            if (bee[2] == 0 && bee[4] == 0)
            {
                if (bee[3] > 30)
                {
                    bee[2] = bee[3] - 30;
                    bee[3] = 30;
                    bee[4] = 1;
                }
            }
        }

        public static void CheckIfBeeIsInHive(char[,] hive, int[] bee)
        {
            if (bee[0] < 0)
            {
                bee[0] = hive.GetLength(0) - 1;
            }
            else if (bee[0] > hive.GetLength(0) - 1)
            {
                bee[0] = 0;
            }
            else if (bee[1] < 0)
            {
                bee[1] = hive.GetLength(1) - 1;
            }
            else if (bee[1] > hive.GetLength(1) - 1)
            {
                bee[1] = 0;
            }
        }

        public static char[,] ReadMatrix(int n, int[] bee)
        {

            char[,] matrix = new char[n, n];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = rowInput[c];

                    if (rowInput[c].ToString() == "B")
                    {
                        bee[0] = r;
                        bee[1] = c;
                    }
                }
            }

            return matrix;
        }

        public static void WriteMatrix<T>(T[,] matrix, Action<T> print)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    print(matrix[r, c]);
                }

                Console.WriteLine();
            }
        }
        enum Direction 
        {
            up,
            down,
            left,
            right
        }
    }
}
