using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise_11_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> filters = new List<string>();
            string input;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] data = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string addOrRemove = data[0];
                string[] arguments = data.Skip(1).ToArray();

                switch (addOrRemove)
                {
                    case "Add filter":
                        filters.Add($"{arguments[0]} {arguments[1]}");
                        break;
                    case "Remove filter":
                        filters.Remove($"{arguments[0]} {arguments[1]}");
                        break;
                }
            }

            foreach (var filter in filters)
            {
                guests = filterList(filter, guests);
            }
            printGuests(guests);
        }

        static Func<string, List<string>, List<string>> filterList = (filter, names) =>
            {
                List<string> filteredGuests = new List<string>();
                string[] arguments = filter.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string condition = arguments[0];
                string parameter = arguments[arguments.Length-1];

                if (condition.StartsWith("Starts"))
                {
                    filteredGuests = names.Where(x => !x.StartsWith(parameter)).ToList();
                }
                else if (condition.StartsWith("Ends"))
                {
                    filteredGuests = names.Where(x => !x.EndsWith(parameter)).ToList();
                }
                else if (condition.StartsWith("Contains"))
                {
                    filteredGuests = names.Where(x => !x.Contains(parameter)).ToList();
                }
                else
                {
                    filteredGuests = names.Where(x => x.Length != int.Parse(parameter)).ToList();
                }

                return filteredGuests;
            };

        public static Action<List<string>> printGuests = guests => Console.WriteLine(string.Join(" ", guests));

    }
}
