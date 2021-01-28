using System;
using System.Linq;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameAdress = Console.ReadLine()
                .Split(" ")
                .ToArray();
            string name = nameAdress[0] + " " + nameAdress[1];
            string street = nameAdress[2];
            string[] cityArr = nameAdress.Skip(3).ToArray();
            string city = $"{string.Join(" ", cityArr)}";

            string[] alcoholCheck = Console.ReadLine()
              .Split(" ")
              .ToArray();
            string nameTwo = alcoholCheck[0];
            int age = int.Parse(alcoholCheck[1]);
            string status = alcoholCheck[2] == "drunk" ? "True" : "False";

            string[] bankAccount = Console.ReadLine()
               .Split(" ")
               .ToArray();
            string nameThree = bankAccount[0];
            double amount = double.Parse(bankAccount[1]);
            string code = bankAccount[2];

            Threeuple<string, string, string> lineOne
                = new Threeuple<string, string, string>(name, street, city);

            Threeuple<string, int, string> lineTWo
                = new Threeuple<string, int, string>(nameTwo, age, status);

            Threeuple<string, double, string> lineThree
                = new Threeuple<string, double, string>(nameThree, amount, code);

            Console.WriteLine(lineOne.ToString());
            Console.WriteLine(lineTWo.ToString());
            Console.WriteLine(lineThree.ToString());

        }
    }
}
