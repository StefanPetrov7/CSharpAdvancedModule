using System;
using System.Collections;

namespace IteratorsAndComparators
{
    public class Lake<T> : IEnumerable<T>
    {
        private readonly T[] arr;

        public Lake(params T[] values)
        {
            this.arr = values.ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.arr.Length; i += 2)
            {
                yield return this.arr[i];
            }

            for (int i = this.arr.Length - 1; i > 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.arr[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

