using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);

                Person newPerson = new Person(age, name);
                family.AddMember(newPerson);

            }

            Person oldest = family.GetOldestMember();

            Console.WriteLine(oldest.ToString());

            foreach (var per in family.People.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine(per.ToString());
            }
        }
    }
}
