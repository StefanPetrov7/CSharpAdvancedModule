using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_03_ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
            string input;

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] cmd = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = cmd[0];
                string product = cmd[1];
                double price = double.Parse(cmd[2]);

                if (shops.ContainsKey(shop) == false)
                {
                    shops.Add(shop, new Dictionary<string, double>() { [product] = price });
                }
                else
                {
                    shops[shop][product] = price;
                }
            }
                
            foreach (var shop in shops.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var products in shop.Value)
                {
                    Console.WriteLine($"Product: {products.Key}, Price: {products.Value}");
                }
            }
        }
    }
}
