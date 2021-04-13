using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> orcs = new Stack<int>();
            bool OrcsWin = false;

            int plate = plates.Dequeue();

            for (int i = 1; i <= waves; i++)
            {

                orcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                int currentOrc = orcs.Pop();

                while (plate > 0)
                {
                    if (plate > currentOrc)
                    {
                        plate -= currentOrc;
                        currentOrc = orcs.Count > 0 ? orcs.Pop() : 0;
                    }
                    else if (plate < currentOrc)
                    {
                        currentOrc -= plate;
                        plate = plates.Count > 0 ? plates.Dequeue() : 0;
                    }
                    else
                    {
                        plate = plates.Count > 0 ? plates.Dequeue() : 0;
                        currentOrc = orcs.Count > 0 ? orcs.Pop() : 0;
                    }

                    if (plates.Count == 0 && plate == 0)
                    {
                        OrcsWin = true;
                        break;
                    }

                    if (orcs.Count == 0 && currentOrc == 0)
                    {
                        break;
                    }
                }

                if (i == waves && OrcsWin == false)
                {
                    plates.Enqueue(plate);
                }

                if (OrcsWin)
                {
                    orcs.Push(currentOrc);
                    break;
                }
            }

            string firstLine = OrcsWin ? "The orcs successfully destroyed the Gondor's defense."
                : "The people successfully repulsed the orc's attack.";

            string secondLine = OrcsWin ? $"Orcs left: {string.Join(", ", orcs.ToList().Select(x => x.ToString()))}"
                : $"Plates left: {string.Join(", ", plates.Select(x => x.ToString()))}";

            Console.WriteLine(firstLine);
            Console.WriteLine(secondLine);
        }
    }
}
