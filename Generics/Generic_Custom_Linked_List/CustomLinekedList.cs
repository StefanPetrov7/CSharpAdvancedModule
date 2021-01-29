using System;
using System.Collections;
using System.Collections.Generic;

namespace Generic_Custom_Linked_List
{
    public class CustomLinekedList : IEnumerable<int>
    {
        public CustomLinekedList()
        {
            this.Count = 0;
        }

        public CustomLinekedList(IEnumerable<int> collection) : this()
        {
            foreach (var item in collection)
            {
                this.AddLast(item);
            }
        }

        public Node First { get; set; }

        public Node Last { get; set; }

        public int Count { get; private set; }

        public void AddFirst(int value)
        {
            Node newElement = new Node(value);

            if (this.First == null)
            {
                this.First = newElement;
                this.Last = newElement;
            }
            else
            {
                newElement.Next = this.First;
                this.First = newElement;
            }

            this.Count++;
        }

        public void AddLast(int value)
        {
            Node newElement = new Node(value);

            if (this.Last == null)
            {
                this.First = newElement;
                this.Last = newElement;
            }
            else
            {
                this.Last.Next = newElement;
                this.Last = newElement;
            }

            this.Count++;
        }

        public void AddBefore(Node node, int value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node cannot be null");
            }

            Node newElement = new Node(value);

            if (node == First)
            {
                newElement.Next = this.First;
                this.First = newElement;
            }
            else
            {
                Node current = this.First;

                while (current != null)
                {
                    if (current.Next == node)
                    {
                        current.Next = newElement;
                        newElement.Next = node;
                        break;
                    }
                    current = current.Next;
                }
            }

            this.Count++;
        }

        public void AddAfter(Node node, int value)
        {

            if (node == null)
            {
                throw new ArgumentNullException("Node cannot be null");
            }

            Node newElement = new Node(value);
            newElement.Next = node.Next;
            node.Next = newElement;
            this.Count++;
        }

        public bool Contains(int value)
        {
            Node current = this.First;
            bool isFound = false;

            while (current != null)
            {
                if (current.Value == value)
                {
                    isFound = true;
                    break;
                }

                current = current.Next;
            }

            return isFound;
        }

        public Node Find(int value)
        {
            Node current = this.First;
            Node result = null;

            while (current != null)
            {
                if (current.Value == value)
                {
                    result = current;
                    break;
                }

                current = current.Next;
            }

            return result;
        }

        public void Remove(int value) // Remove by value;
        {
            Node node = this.Find(value);

            if (node != null)
            {
                Remove(node);
            }
        }

        public void RemoveFirst()
        {
            if (this.First != null)
            {
                if (this.First == this.Last)
                {
                    this.Last = null;
                }

                this.First = this.First.Next;
                this.Count--;
            }
        }

        public void RemoveLast()
        {
            if (this.Last != null)
            {
                if (this.Last == this.First)
                {
                    this.Last = this.First = null;
                }

                Node current = this.First;

                while (current != null)
                {
                    if (current.Next == this.Last)
                    {
                        current.Next = null;
                        this.Last = current;
                        this.Count--;
                    }

                    current = current.Next;
                }
            }
        }

        public void Remove(Node node) // Remove by Node;
        {
            if (node == null)
            {
                throw new AggregateException("Node cannot be null");
            }

            if (node == First)
            {
                this.First = this.First.Next;
            }
            else
            {
                Node current = this.First;

                while (current != null)
                {
                    if (current.Next == node)
                    {
                        current.Next = node.Next;
                        this.Count--;
                        break;
                    }
                    current = current.Next;
                }
            }
        }

        public void RemoveAll(int value)
        {
            Node current = Find(value);

            while (current != null)
            {
                Remove(current);
                current = Find(value);
            }

        }

        public void ForEach(Action<Node> action)
        {
            Node current = this.First;

            while (current != null)
            {
                action(current);
                current = current.Next;
            }

        }

        public IEnumerator<int> GetEnumerator()
        {
            Node current = this.First;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
