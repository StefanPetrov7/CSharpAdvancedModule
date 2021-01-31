using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_01_02_Iterators_And_Comparators
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;

        private int index = 0;

        public ListyIterator(T[] items)
        {
            list = items.ToList();
        }

        public bool Move()
        {
            index++;
            if (list.Count <= index)
            {
                index--;
                return false;
            }

            return true;
        }

        public bool HasNext()
        {
            if (index == list.Count - 1)
            {
                return false;
            }

            return true;

        }

        public void Print()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine($"{list[index]}");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentIndex = 0;

            while (currentIndex<list.Count)
            {
                yield return list[currentIndex];
                currentIndex++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
