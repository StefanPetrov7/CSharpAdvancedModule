namespace IteratorsAndComparators;
class Program
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        Lake<int> lake = new Lake<int>(input);
        Console.WriteLine(string.Join(", ", lake));
    }
}