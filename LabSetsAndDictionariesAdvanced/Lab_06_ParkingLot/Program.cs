using System;
using System.Collections.Generic;

namespace Lab_06_ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            HashSet<string> carLot = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                switch (info[0])
                {
                    case "IN":
                        carLot.Add(info[1]);
                        break;
                    case "OUT":
                        carLot.Remove(info[1]);
                        break;
                }
            }

            if (carLot.Count>0)
            {
                foreach (var car in carLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
        }
    }
}
