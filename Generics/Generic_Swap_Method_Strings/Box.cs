using System;
using System.Collections.Generic;


namespace Generic_Swap_Method_Strings
{
    public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public T Value => this.value;

        public override string ToString()
        {
            return $"{this.value.GetType()}: {value}";
        }

        public static void Swap<T>(List<T> list, int one, int two)
        {
            T elementOne = list[one];
            list[one] = list[two];
            list[two] = elementOne;
        }
    }
}

