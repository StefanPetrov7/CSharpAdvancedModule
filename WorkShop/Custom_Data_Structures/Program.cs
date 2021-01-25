using System;
using System.Collections.Generic;

namespace Custom_Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack customStack = new CustomStack();

            for (int i = 0; i < 10; i++)
            {
                customStack.Push(i);
            }

            customStack.ForEach(x => Console.WriteLine(x));

        }
    }
}
