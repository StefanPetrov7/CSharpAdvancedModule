namespace Practice_2023;

class Matching_Brackets_Updated
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Stack<int> opendBrackets = new Stack<int>();

        for (int i = 0; i < input.Length; i++)
        {
            string curElement = input[i].ToString();

            if (curElement == "(")
            {
                opendBrackets.Push(i);
                continue;
            }

            if (curElement == ")")
            {
                int startIndex = opendBrackets.Pop();
                Console.WriteLine(input.Substring(startIndex, i - startIndex + 1));
                continue;
            }
        }
    }
}
