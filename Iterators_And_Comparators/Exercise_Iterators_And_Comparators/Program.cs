using System;
using System.Linq;

namespace Exercise_01_02_Iterators_And_Comparators
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            ListyIterator<string> collection = new ListyIterator<string>(input.Skip(1).ToArray());

            string cmd;

            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] arg = cmd
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (arg[0])
                {
                    case "Move":
                        if (collection.Move())
                        {
                            Console.WriteLine(true);
                        }
                        else
                        {
                            Console.WriteLine(false);
                        }
                        break;
                    case "HasNext":
                        if (collection.HasNext())
                        {
                            Console.WriteLine(true);
                        }
                        else
                        {
                            Console.WriteLine(false);
                        }
                        break;
                    case "Print":
                        collection.Print();
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", collection));
                        break;
                }
            }
        }
    }
}
