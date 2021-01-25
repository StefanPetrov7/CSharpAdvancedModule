using System;

namespace Custom_Data_Structures
{
    public class CustomStack
    {
        private int[] items;

        private const int InitialCapacity = 4;

        private int count; // => count is locked to changes.

        public CustomStack()
        {
            items = new int[InitialCapacity];
            this.count = 0; // => count is locked to chenages.
        }

        public int Count => this.count;  // this is how we make the count not to be changed out of the class. 

        public void Push(int item)
        {
            if (this.count == this.items.Length)
            {
                Resize(); // using the resize method to double the size of the initial array.
            }

            this.items[this.count++] = item; // Using post incrmentation this.Count++. First we use the count as index and then we add one to it.
        }

        public int Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Custom Stack is Empty");
            }

            if (this.count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            int item = this.items[--this.count];      // Using pre decrementation.
            this.items[this.count] = default;         // [this.count-1] is inside the actual element while [this.count] need to be set as default value, since is removed.
            return item;                              // First we are decreaseing the count and the using it as index to take the elemet. 
        }

        public int Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Custom Stack is Empty");
            }

            int item = this.items[this.count - 1];
            return item;
        }

        private void Shrink()
        {
            int[] temp = new int[this.items.Length / 2];
            Array.Copy(this.items, temp, this.count);
            this.items = temp;
        }

        private void Resize()
        {
            int[] temp = new int[items.Length * 2];
            Array.Copy(this.items, temp, this.items.Length);
            this.items = temp;
        }

        public void ForEach(Action<int> action)
        {
            foreach (var item in this.items)
            {
                if (item == default)
                {
                    break;
                }
                action(item);
            }
        }
    }
}
