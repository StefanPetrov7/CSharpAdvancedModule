using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_05_Comparing_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Person> people = new Dictionary<int, Person>();

            const string END_COMMAND = "END";
            string input;
            int counter = 1;

            while ((input = Console.ReadLine()) != END_COMMAND)
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);
                string town = info[2];
                Person currentPerson = new Person(name, age, town);
                people.Add(counter, currentPerson);
                counter++;
            }

            int n = int.Parse(Console.ReadLine());
            Person comparedPerson = people.Where(x => x.Key == n).Select(x => x.Value).FirstOrDefault();
            int matches = 1;

            foreach (var person in people.Where(x => x.Key != n).ToDictionary(a => a.Key, b => b.Value))
            {
                int result = comparedPerson.CompareTo(person.Value);

                if (result == 0)
                {
                    matches++;
                }
            }

            if (matches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
            }
        }
    }
}
