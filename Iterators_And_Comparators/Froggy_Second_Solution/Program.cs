using System;
using System.Linq;

namespace Froggy_Second_Solution
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Lake lake = new Lake(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            //lake.OrderElements();   // => Solution one 
            Console.WriteLine(string.Join(", ", lake));   // => sorted in the GetEnumerator() method
        }
    }
}
