using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercise_04_Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly int[] array;

        public Lake(params int[] stones)
        {
            array = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {

            List<int> tempEven = new List<int>();
            List<int> tempOdd = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    tempEven.Add(array[i]);
                }
                else
                {
                    tempOdd.Insert(0, array[i]);
                }
            }

            Array.Copy(tempEven.ToArray(), array, tempEven.Count);
            Array.Copy(tempOdd.ToArray(), 0, array, tempEven.Count, tempOdd.Count);

            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
