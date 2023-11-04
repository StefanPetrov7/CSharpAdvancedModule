using System.Linq;
using System.Threading.Channels;

namespace Offroad_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ALTITUDE_REACHED = "John has reached: Altitude {0}";
            const string ALTITUDE_NOT_REACHED = "John did not reach: Altitude {0}";
            const string FAIL_TO_REACH_TOP = "John failed to reach the top.";

            Stack<int> fuelStart = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> consumptionIndexStart = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int[] fuelNeededStart = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<string> reachedAltitudes = new List<string>();

            bool reachedTop = true;

            for (int i = 1; i <= fuelNeededStart.Length; i++)
            {
                int fuel = fuelStart.Pop();
                int index = consumptionIndexStart.Dequeue();
                int neededFuel = fuelNeededStart[i - 1];

                int result = fuel - index;

                if (result >= neededFuel)
                {
                    reachedAltitudes.Add($"Altitude {i}");
                    Console.WriteLine(string.Format(ALTITUDE_REACHED, i));
                }
                else
                {
                    reachedTop = false;
                    Console.WriteLine(string.Format(ALTITUDE_NOT_REACHED, i));
                    break;
                }
            }

            if (reachedTop == false)
            {
                Console.WriteLine(FAIL_TO_REACH_TOP);

                if (reachedAltitudes.Count == 0)
                {
                    Console.WriteLine("John didn't reach any altitude.");
                }
                else
                {
                    Console.WriteLine("Reached altitudes: " + string.Join(", ", reachedAltitudes));
                }
            }
            else
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
        }
    }
}