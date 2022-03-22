using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic_SecondSolution
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashPeople = new HashSet<Person>();
            SortedSet<Person> setPeople = new SortedSet<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var arg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Person person = new Person(arg[0], int.Parse(arg[1]));
                hashPeople.Add(person);
                setPeople.Add(person);
            }

            Console.WriteLine(hashPeople.Count);
            Console.WriteLine(setPeople.Count);
        }
    }
}
