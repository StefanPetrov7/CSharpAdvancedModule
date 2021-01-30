using System;

namespace Generic_Custom_Linked_List
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }

        public T Value { get; set; }

    }
}