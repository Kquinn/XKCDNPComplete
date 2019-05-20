using System;
using System.Collections.Generic;

namespace NP_CompleteOrder
{
    public class BaseNToIntegerArray
    {
        public static int[] Convert(long index, int numberBase)
        {
            List<int> output = new List<int>();
            while (index > 0)
            {
                output.Add((int)index % numberBase);
                index = (long)Math.Floor((double)index / numberBase);
            }

            return output.ToArray();
        }
    }
}
