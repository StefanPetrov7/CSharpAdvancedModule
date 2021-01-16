using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise_11_X_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<Func<string, string, bool>> filterList = new List<Func<string, string, bool>>();
            List<string> parameters = new List<string>();

            Func<string, string, bool> startWith = (name, argument) =>
            {
                bool flag = name.StartsWith(argument) ? true : false;
                return flag;
            };

            Func<string, string, bool> endsWith = (name, argument) =>
            {
                bool flag = name.EndsWith(argument) ? true : false;
                return flag;
            };

            Func<string, string, bool> contains = (name, argument) =>
            {
                bool flag = name.Contains(argument) ? true : false;
                return flag;
            };

            Func<string, string, bool> length = (name, argument) =>
            {
                int length = int.Parse(argument);
                bool flag = name.Length == length ? true : false;
                return flag;
            };

            string input;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] data = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string filterType = data[1];
                string filterArg = data[2];
                char command = data[0][0];

                switch (filterType)
                {
                    case "Starts with":
                        if (command == 'A')
                        {
                            filterList.Add(startWith);
                            parameters.Add(filterArg);
                        }
                        else
                        {
                            filterList.Remove(startWith);
                            parameters.Remove(filterArg);
                        }
                        break;
                    case "Ends with":
                        if (command == 'A')
                        {
                            filterList.Add(endsWith);
                            parameters.Add(filterArg);
                        }
                        else
                        {
                            filterList.Remove(endsWith);
                            parameters.Remove(filterArg);
                        }
                        break;
                    case "Length":
                        if (command == 'A')
                        {
                            filterList.Add(length);
                            parameters.Add(filterArg);
                        }
                        else
                        {
                            filterList.Remove(length);
                            parameters.Remove(filterArg);
                        }
                        break;
                    case "Contains":
                        if (command == 'A')
                        {
                            filterList.Add(contains);
                            parameters.Add(filterArg);
                        }
                        else
                        {
                            filterList.Remove(contains);
                            parameters.Remove(filterArg);
                        }
                        break;
                }
            }

            for (int i = 0; i < parameters.Count; i++)
            {
                for (int j = 0; j < guests.Count; j++)
                {
                    if (filterList[i](guests[j], parameters[i]))
                    {
                        guests.Remove(guests[j]);
                        j--;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", guests));
        }
    }
}