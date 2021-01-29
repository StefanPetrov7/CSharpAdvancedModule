using System;

namespace Generic_Custom_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinekedList linkedList = new CustomLinekedList();

            for (int i = 0; i < 5; i++)
            {
                linkedList.AddFirst(i);
            }

            Node nodeV2 = linkedList.Find(2);

            linkedList.AddAfter(nodeV2, 100);

            Node nodeRemove = linkedList.Find(100);

            linkedList.Remove(nodeRemove);

            linkedList.ForEach(node => Console.WriteLine(node.Value));

        }
    }
}
