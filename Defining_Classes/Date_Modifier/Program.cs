using System;

namespace Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayOne = Console.ReadLine();
            string dayTwo = Console.ReadLine();
            Console.WriteLine(DateModifier.GetDaysDifference(dayOne, dayTwo)); 
        }
    }
}
