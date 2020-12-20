using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab06Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people = new Queue<string>();

            string input;

            while ((input=Console.ReadLine())!="End")
            {
                if (input=="Paid")
                {
                    int num = people.Count;

                    for (int i = 0; i < num; i++)
                    {
                        Console.WriteLine(people.Dequeue());
                    }
                }
                else
                {
                    people.Enqueue(input);
                }
                
            }

            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}
