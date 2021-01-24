using System;
using System.Collections.Generic;

namespace Game_Snake
{
    public class LinkedList
    {
        public LinkedList()
        {
        }

        public Node Head { get; set; }

        public Node Tail { get; set; }

        public void ForEach(Action<Node> action)  
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }
        }

        public void ReverseForEach(Action<Node> action)
        {
            Node currentNode = Tail;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Previous;
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

        public Node Peek()
        {
            return this.Head;
        }

        public void PrintList() 
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
