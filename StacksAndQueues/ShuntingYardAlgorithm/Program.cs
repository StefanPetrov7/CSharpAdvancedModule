using System;
using System.Collections.Generic;
using System.Linq;

namespace ShuntingYardAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RPNCalculator(ShuntingYard(Console.ReadLine())));
        }

        static string RPNCalculator(string input)
        {
            string[] expression = input
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Reverse()
               .ToArray();

            Stack<string> stack = new Stack<string>(expression);

            while (stack.Count > 2)
            {
                PrintStack(stack);

                List<string> ellements = new List<string>();

                var curEllement = stack.Pop();

                while (IsOperator(curEllement) == false)
                {
                    ellements.Add(curEllement);
                    curEllement = stack.Pop();
                }

                int first = int.Parse(ellements[ellements.Count - 2]);
                int second = int.Parse(ellements[ellements.Count - 1]);

                int result = PerformOperation(curEllement, first, second);

                stack.Push(result.ToString());

                for (int i = ellements.Count - 3; i >= 0; i--)
                {
                    stack.Push(ellements[i]);
                }
            }

            return stack.Pop();
        }

        static string ShuntingYard(string input)
        {
            string[] expression = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> operatorStack = new Stack<string>();
            string output = string.Empty;

            for (int i = 0; i < expression.Length; i++)
            {
                if (IsOperator(expression[i]))
                {
                    if (operatorStack.Count > 0)
                    {
                        var oldEllementArity = OperatorPrecidence(operatorStack.Peek());

                        var ellementArity = OperatorPrecidence(expression[i]);

                        if (oldEllementArity >= ellementArity)
                        {
                            output += operatorStack.Pop() + " ";
                        }
                    }

                    operatorStack.Push(expression[i]);

                }
                else if (expression[i] == "(")
                {
                    operatorStack.Push(expression[i]);
                }
                else if (expression[i] == ")")
                {
                    while (operatorStack.Peek() != "(")
                    {
                        output += operatorStack.Pop() + " ";
                    }
                    operatorStack.Pop();
                }
                else
                {
                    output += expression[i] + " ";
                }
            }

            while (operatorStack.Count > 0)
            {
                output += operatorStack.Pop() + " ";
            }

            return output;
        }

        static int OperatorPrecidence(string input)
        {
            switch (input)
            {
                case "+":
                    return 2;
                case "-":
                    return 2;
                case "/":
                    return 3;
                case "*":
                    return 3;
                case "(":
                    return 1;
            }
            throw new ArgumentException();
        }

        static bool IsOperator(string item)
        {
            switch (item)
            {
                case "+":
                    return true;
                case "-":
                    return true;
                case "/":
                    return true;
                case "*":
                    return true;
            }
            return false;
        }

        private static int PerformOperation(string item, int first, int second)
        {
            switch (item)
            {
                case "+":
                    return first + second;
                case "-":
                    return first - second;
                case "/":
                    return first / second;
                case "*":
                    return first * second;
            }
            throw new ArgumentException();
        }

        static void PrintStack(Stack<string> stack)
        {
            foreach (var item in stack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
