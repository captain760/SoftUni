using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake:IEnumerable<int>
    {
        private int[] stones;
       
        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] result = new int[stones.Length];
            int index = 0;
            for (int i = 0; i < stones.Length; i+=2)
            {
                result[index] = stones[i];
                index++;
            }
            int k = stones.Length;
            if (stones.Length%2!=0)
            {
                k--;
            }
            for (int i = k - 1; i >= 0; i-=2)
            {
                result[index] = stones[i];
                index++;
            }
            foreach (var item in result)
            {
                yield return item;
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}
