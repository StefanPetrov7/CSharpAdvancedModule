using System;

namespace Lab_05_Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people[i] = new Person(input[0], int.Parse(input[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> conditionDelegate = GetCondition(condition, age);
            Action<Person> printerDelegate = Print(format);

            FilterPeople(people, conditionDelegate, printerDelegate);
            // FilterPeople(people, x => x.Age > 50, printerDelegate); 
            // FilterPeople(people, x => true, x => Console.WriteLine($"{x.Name} !!!!!")); 

        }

        static void FilterPeople(Person[] people, Func<Person, bool> filter, Action<Person> print)
        {
            foreach (var person in people)
            {
                if (filter(person))
                {
                    print(person);
                }
            }
        }

        static Action<Person> Print(string format)
        {
            switch (format)
            {
                case "name": return x => Console.WriteLine($"{x.Name}");
                case "age": return x => Console.WriteLine($"{x.Age}");
                case "name age": return x => Console.WriteLine($"{x.Name} - {x.Age}");
                default: return null;
            }
        }

        static Func<Person, bool> GetCondition(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return x => x.Age < age;
                case "older": return x => x.Age >= age;
                default: return null;
            }
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }
    }
}
