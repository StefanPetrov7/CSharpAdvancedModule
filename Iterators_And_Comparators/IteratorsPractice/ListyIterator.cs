using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsPractice
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;

        private int index;

        public ListyIterator()
        {
            this.collection = new List<T>();
            this.index = 0;
        }

        public ListyIterator(params T[] items) : this()
        {
            this.collection = items.ToList();
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }

            return this.HasNext();
        }

        public bool HasNext() => this.index < this.collection.Count - 1;

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.collection[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {

            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }

            //return this.collection.GetEnumerator(); // => use the GetEnumerator() method from the internal collection 

            //return new Iterator<T>(this.collection); // => use internal class Iterator to return IEnumerator<T> 

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //public class Iterator<T> : IEnumerator<T>  
    //{
    //    private List<T> list;
    //    private int index;

    //    public Iterator(List<T> list)
    //    {
    //        this.Reset();
    //        this.list = list;
    //    }

    //    public T Current => this.list[index];

    //    object IEnumerator.Current => this.Current;

    //    public void Dispose() { }

    //    public bool MoveNext()
    //    {
    //        return ++index < this.list.Count;
    //    }

    //    public void Reset()
    //    {
    //        index = -1;
    //    }
    //}
}
