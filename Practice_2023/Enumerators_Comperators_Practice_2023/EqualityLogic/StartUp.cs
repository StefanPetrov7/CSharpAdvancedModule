namespace EqualityLogic;

class Program
{
    static void Main(string[] args)
    {
        HashSet<Person> hashPeaople = new HashSet<Person>();
        SortedSet<Person> sortSetPeaople = new SortedSet<Person>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] arg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            hashPeaople.Add(new Person(arg[0], int.Parse(arg[1])));
            sortSetPeaople.Add(new Person(arg[0], int.Parse(arg[1])));
        }

        Console.WriteLine(sortSetPeaople.Count);
        Console.WriteLine(hashPeaople.Count);

    }
}