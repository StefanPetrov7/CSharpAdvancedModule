using System;

namespace Generic_Custom_Linked_List
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomLinekedList<int> linkedList = new CustomLinekedList<int>();

            for (int i = 0; i < 5; i++)
            {
                linkedList.AddFirst(i);
            }

            linkedList.AddFirst(20);

            linkedList.ForEach(node => Console.WriteLine(node.Value));

            Node<string> newNode = new Node<string>("Stefan");

            CustomDoublyLinkeList<string> list = new CustomDoublyLinkeList<string>();

            list.AddHead(newNode);

        }
    }
}
