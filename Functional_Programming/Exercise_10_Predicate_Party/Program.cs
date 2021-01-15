using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_10_Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, string, string, bool> validCriteria = (name, criteria, data) =>
            {
                bool flag;

                if (criteria == "StartsWith")
                {
                    flag = name.StartsWith(data) ? true : false;
                }
                else if (criteria == "EndsWith")
                {
                    flag = name.EndsWith(data) ? true : false;
                }
                else
                {
                    flag = name.Length == int.Parse(data) ? true : false;
                }
                return flag;
            };

            string input;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = cmd[0];
                string criteria = cmd[1];
                string details = cmd[2];

                switch (command)
                {
                    case "Remove":
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (validCriteria(guests[i], criteria, details))
                            {
                                guests.RemoveAll(x => x == guests[i]);
                            }
                        }
                        break;
                    case "Double":
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (validCriteria(guests[i], criteria, details))
                            {
                                guests.Insert(i, guests[i]);
                                i++;
                            }
                        }
                        break;
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }
    }
}

