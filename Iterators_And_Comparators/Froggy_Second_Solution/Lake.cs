using System;
using System.Collections;
using System.Collections.Generic;

namespace Froggy_Second_Solution
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(params int[] stones)
        {
            this.stones = stones;
        }

        public void OrderElements()  // Solution one 
        {
            List<int> even = new List<int>();
            List<int> odd = new List<int>();

            for (int i = 0; i < this.stones.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even.Add(this.stones[i]);
                }
                else
                {
                    odd.Add(this.stones[i]);
                }
            }

            odd.Reverse();
            even.AddRange(odd);
            this.stones = even.ToArray();
        }

        public IEnumerator<int> GetEnumerator()   // Second Solution 
        {
            for (int i = 0; i < this.stones.Length; i += 2)
            {
                yield return this.stones[i];
            }

            int startIndex = this.stones.Length % 2 == 0 ? this.stones.Length - 1 : this.stones.Length - 2;

            for (int i = startIndex; i >= 0; i -= 2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
