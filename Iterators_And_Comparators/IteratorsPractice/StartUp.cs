using System;
using System.Linq;

namespace IteratorsPractice
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            string[] create = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ListyIterator<string> list = new ListyIterator<string>(create.Skip(1).ToArray());

            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "PrintAll":
                        try
                        {
                            Console.WriteLine(string.Join(" ", list));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
        }
    }
}
