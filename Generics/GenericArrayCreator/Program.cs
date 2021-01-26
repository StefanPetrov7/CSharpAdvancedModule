using System;


namespace GenericArrayCreator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] array = ArrayCreator.Create(5, "Stefan");

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
