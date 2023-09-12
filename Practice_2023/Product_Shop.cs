using System.Diagnostics;

namespace Practice_2023;

class Product_Shop
{
    static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

        string input;

        while ((input = Console.ReadLine()) != "Revision")
        {
            string[] arg = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string shop = arg[0];
            string product = arg[1];
            double price = double.Parse(arg[2]);

            if (shops.ContainsKey(shop) == false)
            {
                shops[shop] = new Dictionary<string, double>();
            }

            shops[shop][product] = price;
        }

        foreach (var shop in shops.OrderBy(x => x.Key)) 
        {
            Console.WriteLine($"{shop.Key}->");

            foreach (var product in shop.Value)
            {
                Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
            }
        }
    }
}