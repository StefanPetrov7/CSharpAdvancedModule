using System.Text;

namespace Practice_2023;

class Matching_Brackets
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Stack<int> opendBrackets = new Stack<int>();
        Stack<int> openCloseBrackets = new Stack<int>();
        Stack<string> result = new Stack<string>();

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
                openCloseBrackets.Push(opendBrackets.Pop());
                openCloseBrackets.Push(i);
                continue;
            }
        }

        int counter = openCloseBrackets.Count;

        for (int i = 0; i < counter / 2; i++)
        {
            int closeIndex = openCloseBrackets.Pop();
            int startIndex = openCloseBrackets.Pop();
            int legth = closeIndex - startIndex;
            string element = input.Substring(startIndex, legth + 1);
            result.Push(element);
        }

        while (result.Count > 0)
        {
            Console.WriteLine(result.Pop());
        }
    }
}
