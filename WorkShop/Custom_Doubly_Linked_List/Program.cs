using System;

namespace Custom_Doubly_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            for (int i = 0; i < 5; i++)
            {
                Node node = new Node(i);
                list.AddHead(node);
            }

            for (int i = 0; i < 5; i++)
            {
                Node node = new Node(i);
                list.AddLast(node);
            }




        }
    }
}
