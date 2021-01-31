using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercise_03_Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] array;

        private int count;

        const int initialCApacity = 4;

        public int manualCapacity;

        public CustomStack()
        {
            array = new T[initialCApacity];
            this.count = 0;
        }

        public CustomStack(int capacity) : this()
        {
            manualCapacity = capacity;
            array = new T[manualCapacity];
        }

        public int Count => this.count;

        public void Push(T element)
        {
            if (this.Count == array.Length)
            {
                Resize();
            }

            array[count] = element;
            count++;
        }

        public T Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            else
            {
                T element = array[--count];
                array[count] = default;

                if (this.count <= array.Length / 4)
                {
                    Shrink();
                }

                return element;
            }

        }

        private void Shrink()
        {
            T[] temp = new T[array.Length / 2];
            Array.Copy(array, temp, count);
            array = temp;
        }

        private void Resize()
        {
            T[] temp = new T[array.Length * 2];
            Array.Copy(array, temp, count);
            array = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int iterationCount = count - 1;

            while (iterationCount >= 0)
            {
                yield return array[iterationCount];
                iterationCount--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
