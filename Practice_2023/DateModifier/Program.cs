namespace DateModifier;
public class Program
{
    static void Main(string[] args)
    {
        int[] dateOne = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[] dateTwo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        TimeSpan result = DateModifier.CalculateDateDifference(dateOne, dateTwo);
        int days = Math.Abs(int.Parse(result.Days.ToString()));
        Console.WriteLine(days);
    }
}

