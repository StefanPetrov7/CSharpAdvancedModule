using System;
using System.Collections.Generic;

namespace Custom_Doubly_Linked_List
{
    public class LinkedList
    {
        public LinkedList()
        {
        }

        public Node Head { get; set; }

        public Node Tail { get; set; }

        public void ForEach(Action<Node> action)  // Delegat;
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }
        }

        public Node[] ToArray()
        {
            List<Node> list = new List<Node>();
            this.ForEach(node => list.Add(node));
            return list.ToArray();
        }

        public void AddHead(Node newHead)
        {
            if (Head == null)
            {
                Head = newHead;
                Tail = newHead;
            }
            else
            {
                newHead.Next = Head;
                Head.Previous = newHead;
                Head = newHead;
            }
        }

        public void AddLast(Node newTail)
        {
            if (Tail == null)
            {
                Head = newTail;
                Tail = newTail;
            }
            else
            {
                newTail.Previous = Tail;
                Tail.Next = newTail;
                Tail = newTail;
            }
        }

        public Node RemoveFirst()
        {
            var removedHead = this.Head;
            this.Head = this.Head.Next;
            Head.Previous = null;
            return removedHead;
        }

        public Node RemoveLast()
        {
            var removedTail = this.Tail;
            this.Tail = this.Tail.Previous;
            Tail.Next = null;
            return removedTail;
        }

        public bool Remove(int value)
        {
            Node currentNode = this.Head;

            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    currentNode.Previous.Next = currentNode.Next;
                    currentNode.Next.Previous = currentNode.Previous;
                    return true;
                }

                currentNode = currentNode.Next;

            }

            return false;
        }

        public bool Contains(int value)
        {
            bool isFound = false;

            ForEach(node =>
            {
                if (node.Value == value)
                {
                    isFound = true;
                }
            });

            return isFound;

        }

        public int Peek()
        {
            return this.Head.Value;
        }

        public void PrintList() // uses ForEach as delegat 
        {
            this.ForEach(node => Console.WriteLine(node.Value));
        }

        public void ReversePrintList()
        {
            Node currentNode = Tail;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Previous;
            }
        }
    }
}
