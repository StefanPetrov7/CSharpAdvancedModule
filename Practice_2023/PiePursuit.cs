namespace PiePursuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> contestants = new(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> pies = new(Console.ReadLine().Split(" ").Select(int.Parse));

            while (contestants.Count > 0 && pies.Count > 0)
            {
                int contestant = contestants.Dequeue();
                int curPie = pies.Pop();

                if (contestant >= curPie)
                {
                    contestant -= curPie;
                    curPie = 0;

                    if (contestant > 0)
                    {
                        contestants.Enqueue(contestant);
                    }
                }
                else
                {
                    curPie -= contestant;

                    if (curPie == 1 && pies.Count > 1)
                    {
                        int nextPie = pies.Pop();
                        nextPie += curPie;
                        pies.Push(nextPie);
                    }
                    else
                    {
                        pies.Push(curPie);
                    }
                }
            }

            if (pies.Count == 0 && contestants.Count == 0)
            {
                Console.WriteLine("We have a champion!");
            }
            else if (pies.Count == 0)
            {
                Console.WriteLine("We will have to wait for more pies to be baked!");
                Console.WriteLine($"Contestants left: {string.Join(", ", contestants)}");
            }
            else
            {
                Console.WriteLine("Our contestants need to rest!");
                Console.WriteLine($"Pies left: {string.Join(", ", pies)}");
            }
        }
    }
}
