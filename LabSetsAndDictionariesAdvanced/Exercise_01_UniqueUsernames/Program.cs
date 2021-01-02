using System;
using System.Collections.Generic;

namespace Exercise_01_UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> users = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                users.Add(Console.ReadLine());
            }

            foreach (var name in users)
            {
                Console.WriteLine(name);
            }
        }
    }
}
