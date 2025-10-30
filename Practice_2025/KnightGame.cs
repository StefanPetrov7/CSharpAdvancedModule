namespace KnightGame
{
    public class KnightGame
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            List<Horse> horses = new List<Horse>();

            string[,] matrix = ReadMatrix(size, horses);

            int removedHorses = RemoveHorses(matrix, horses);

            Console.WriteLine(removedHorses);

        }

        public static int RemoveHorses(string[,] matrix, List<Horse> horses)
        {
            int result = 0;

            while (true)
            {
                var bestHorse = new Horse();

                for (int i = 0; i < horses.Count; i++)
                {
                    Horse curHorse = horses[i];

                    if (CheckIfIndexIsValid(matrix, curHorse.Row - 2, curHorse.Col - 1) && CheckIfIndexIsK(matrix, curHorse.Row - 2, curHorse.Col - 1))
                    {
                        curHorse.Kills++;
                    }

                    if (CheckIfIndexIsValid(matrix, curHorse.Row - 2, curHorse.Col + 1) && CheckIfIndexIsK(matrix, curHorse.Row - 2, curHorse.Col + 1))
                    {
                        curHorse.Kills++;
                    }

                    if (CheckIfIndexIsValid(matrix, curHorse.Row - 1, curHorse.Col - 2) && CheckIfIndexIsK(matrix, curHorse.Row - 1, curHorse.Col - 2))
                    {
                        curHorse.Kills++;
                    }

                    if (CheckIfIndexIsValid(matrix, curHorse.Row + 1, curHorse.Col - 2) && CheckIfIndexIsK(matrix, curHorse.Row + 1, curHorse.Col - 2))
                    {
                        curHorse.Kills++;
                    }

                    if (CheckIfIndexIsValid(matrix, curHorse.Row + 2, curHorse.Col - 1) && CheckIfIndexIsK(matrix, curHorse.Row + 2, curHorse.Col - 1))
                    {
                        curHorse.Kills++;
                    }

                    if (CheckIfIndexIsValid(matrix, curHorse.Row + 2, curHorse.Col + 1) && CheckIfIndexIsK(matrix, curHorse.Row + 2, curHorse.Col + 1))
                    {
                        curHorse.Kills++;
                    }

                    if (CheckIfIndexIsValid(matrix, curHorse.Row - 1, curHorse.Col + 2) && CheckIfIndexIsK(matrix, curHorse.Row - 1, curHorse.Col + 2))
                    {
                        curHorse.Kills++;
                    }

                    if (CheckIfIndexIsValid(matrix, curHorse.Row + 1, curHorse.Col + 2) && CheckIfIndexIsK(matrix, curHorse.Row + 1, curHorse.Col + 2))
                    {
                        curHorse.Kills++;
                    }

                    if (bestHorse.Kills < curHorse.Kills)
                    {
                        bestHorse = curHorse;
                    }

                }

                if (bestHorse.Kills > 0)
                {
                    horses.Remove(bestHorse);
                    matrix[bestHorse.Row, bestHorse.Col] = "0";
                    result++;

                    foreach (var horse in horses)
                    {
                        horse.Kills = 0;
                    }
                }
                else
                {
                    break;
                }

            }

            return result;
        }

        public static bool CheckIfIndexIsValid(string[,] matrix, int row, int col) => row >= 0 && row < matrix.GetLength(0) && col >= 0 & col < matrix.GetLength(1);

        public static bool CheckIfIndexIsK(string[,] matrix, int row, int col) => matrix[row, col] == "K";

        public static string[,] ReadMatrix(int size, List<Horse> horses)
        {
            string[,] matrix = new string[size, size];

            for (int r = 0; r < size; r++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = input[c].ToString();

                    if (matrix[r, c] == "K")
                    {
                        Horse horse = new Horse();
                        horse.Row = r;
                        horse.Col = c;
                        horses.Add(horse);
                    }
                }
            }

            return matrix;
        }
    }

    public class Horse
    {
        public Horse()
        { }

        public int Kills { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

    }
}
