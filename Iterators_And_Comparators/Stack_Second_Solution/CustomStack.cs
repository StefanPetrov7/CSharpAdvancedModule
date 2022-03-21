using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack_Second_Solution
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> list;  // => !List structure should never be used to implement stack based structures. Resizing will be slow. 

        private int index;

        public CustomStack()
        {
            this.list = new List<T>();
            this.index = -1;
        }

        public void Push(T element)
        {
            this.list.Add(element);
            index++;
        }

        public void Pop()
        {
            if (index < 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T element = this.list[index--];
            this.list.Remove(element);
            return;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.list.Count - 1; i >= 0; i--)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
