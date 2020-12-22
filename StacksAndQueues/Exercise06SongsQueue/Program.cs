using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise06SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songsList = new Queue<string>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray());

            while (songsList.Count>0)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case"Play":
                        songsList.Dequeue();
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songsList));
                        break;
                    default:
                        string song = command.Substring(4);
                        if (songsList.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            songsList.Enqueue(song);
                        }
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
