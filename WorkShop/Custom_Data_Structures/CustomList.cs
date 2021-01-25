using System;

namespace Custom_Data_Structures
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize(); // using the resize method to double the size of the initial array.
            }
            this.items[this.Count++] = item; // Using post incrmentation this.Count++. First we use the count as index and then we add one to it.
        }

        public int RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int value = this.items[index];

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            this.Shift(index);
            this.items[--this.Count] = 0; // Inside Array count last element is set to 0 value. 
            return value;                 // Count has been decreased with one since we remove one element, using pre-decremantation.
        }

        public void Insert(int index, int item)
        {
            if (index > this.Count)  // to check if the index is not inseted as last index => index > index.Count.
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftRight(index);
            this.items[index] = item;
            this.Count++;
        }

        public bool Contains(int item)
        {
            bool contains = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (item == this[i])
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >= this.Count || secondIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count - 1; i >= index - 1; i--)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i + 1] = this.items[i];
            }
        }

        private void Shrink()
        {
            int newLength = this.items.Length / 2;
            int[] temp = new int[newLength];
            Array.Copy(this.items, temp, this.Count);
            this.items = temp;
        }

        private void Resize()
        {
            int[] temp = new int[this.items.Length * 2];
            Array.Copy(this.items, temp, this.items.Length);
            this.items = temp; // items[] change the reference to temp[].
        }
    }
}
