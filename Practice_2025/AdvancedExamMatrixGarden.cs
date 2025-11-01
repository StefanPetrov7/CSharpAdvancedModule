namespace AdvanceExamClearSkies
{
    public class AdvancedExamMatrixGarden
    {
        static void Main(string[] args)
        {

            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = ReadMatrix(size[0], size[1]);
            List<Flower> flowers = new List<Flower>();
            string cmd = string.Empty;

            while (true)
            {
                cmd = Console.ReadLine();

                if (cmd[0].ToString() != "B")
                {
                    Flower flower = new Flower();
                    int[] coordinates = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    flower.Row = coordinates[0];
                    flower.Col = coordinates[1];
                    flowers.Add(flower);
                }
                else
                {
                    for (int i = 0; i < flowers.Count; i++)
                    {
                        if (IsIndexValid(flowers[i].Row, flowers[i].Col, matrix))
                        {
                            matrix[flowers[i].Row, flowers[i].Col] = 1;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates.");
                        }
                    }

                    IncreaseValueRowsCols(flowers, matrix);
                    break;

                }
            }

            PrintMatrix(matrix);

        }



        public static void IncreaseValueRowsCols(List<Flower> flowers, int[,] matrix)
        {
            foreach (var flower in flowers)
            {
                for (int c = flower.Col + 1; c < matrix.GetLength(1); c++)
                {
                    if (IsIndexValid(flower.Row, c, matrix))
                    {
                        matrix[flower.Row, c]++;
                    }
                }

                for (int c = flower.Col - 1; c >= 0; c--)
                {
                    if (IsIndexValid(flower.Row, c, matrix))
                    {
                        matrix[flower.Row, c]++;
                    }
                }

                for (int r = flower.Row + 1; r < matrix.GetLength(0); r++)
                {
                    if (IsIndexValid(r, flower.Col, matrix))
                    {
                        matrix[r, flower.Col]++;
                    }
                }

                for (int r = flower.Row - 1; r >= 0; r--)
                {
                    if (IsIndexValid(r, flower.Col, matrix))
                    {
                        matrix[r, flower.Col]++;
                    }
                }
            }
        }

        public static bool IsIndexValid(int row, int col, int[,] matrix) => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        public static void PrintMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }

                Console.WriteLine();
            }
        }

        public static int[,] ReadMatrix(int row, int col)
        {
            int[,] matrix = new int[row, col];

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = 0;
                }
            }

            return matrix;
        }
    }

    public class Flower
    {
        public Flower()
        { }

        public int Row { get; set; }

        public int Col { get; set; }

    }
}
