using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise09SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> textStack = new Stack<string>();
            int interations = int.Parse(Console.ReadLine());

            for (int i = 0; i < interations; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = cmd[0];

                switch (command)
                {
                    case "1":
                        string text = cmd[1];
                        textStack.Push(text);
                        break;

                    case "2":
                        int charsToRemove = int.Parse(cmd[1]);
                        text = textStack.Peek().Remove(textStack.Peek().Length - charsToRemove);
                        textStack.Push(text);
                        break;

                    case "3":
                        int charToPrint = int.Parse(cmd[1]) - 1;
                        Console.WriteLine(textStack.Peek().Substring(charToPrint, 1));
                        break;

                    case "4":
                        textStack.Pop();
                        break;
                }
            }

        }
    }
}
