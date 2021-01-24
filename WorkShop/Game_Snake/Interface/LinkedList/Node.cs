using System;

namespace Game_Snake
{
    public class Node
    {
        public Node(Possition value)
        {
            this.Value = value;
        }

        public Possition Value { get; set; }

        public Node Next { get; set; }

        public Node Previous { get; set; }

    }
}
