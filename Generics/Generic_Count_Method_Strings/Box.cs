using System;
using System.Collections.Generic;

namespace Generic_Swap_Method_Strings_Double
{
    public class Box<T> where T : IComparable
    {
        public Box(List<T> value)
        {
            this.Value = value;
        }

        public List<T> Value { get; set; }

        public override string ToString()
        {
            return $"{this.Value.GetType()}: {this.Value}";
        }

        public static void Swap<T>(List<T> list, int one, int two)
        {
            T elementOne = list[one];
            list[one] = list[two];
            list[two] = elementOne;
        }

        public int GetCountGraterElements(List<T> list, T element)
        {
            int result = 0;

            foreach (var item in list)
            {
                int num = item.CompareTo(element);
                result = num > 0 ? result += 1 : result;
            }

            return result;
        }
    }
}

