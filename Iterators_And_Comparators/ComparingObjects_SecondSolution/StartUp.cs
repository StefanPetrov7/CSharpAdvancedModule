using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects_SecondSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var arg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Person person = new Person(arg[0], int.Parse(arg[1]), arg[2]);
                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine());
            Person comapredPerson = people[n - 1];
            string statistics = GetStatistic(comapredPerson, people);
            Console.WriteLine(statistics);

        }

        private static string GetStatistic(Person person, List<Person> people)
        {

            int equal = 0;
            int notEqual = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (person.CompareTo(people[i]) != 0)
                {
                    notEqual++;
                }
                else
                {
                    equal++;
                }
            }

            string result = equal != 1 ? $"{equal} {notEqual} {people.Count}" : $"No matches";
            return result;
        }
    }
}
