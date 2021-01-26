using System;

using System.Collections.Generic;

namespace BoxofT
{
    public class Box<T>
    {
        private Stack<T> stack;

        public Box()
        {
            this.stack = new Stack<T>();
        }

        public int Count
        {
            get { return this.stack.Count; }
        }

        public void Add(T element)
        {
            this.stack.Push(element);
        }

        public T Remove()
        {
            return this.stack.Pop();
        }
    }
}
