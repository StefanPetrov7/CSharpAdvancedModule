using System;

namespace Generic_Custom_Linked_List
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }

        public Node Next { get; set; }

        public Node Previous { get; set; }

        public int Value { get; set; }

    }
}