using System;
using System.Collections.Generic;

namespace Exercise_06_Equality_Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashset = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);

                Person curPerson = new Person(name, age);
                sortedSet.Add(curPerson);
                hashset.Add(curPerson);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashset.Count);
        } 
    }
}
