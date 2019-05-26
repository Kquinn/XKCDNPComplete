using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP_CompleteOrder
{
    public class ZeroArray
    {
        public static int[] Create(int length)
        {
            int[] output = new int[length];
            for(int i = 0; i<length;i++)
            {
                output[i] = 0;
            }
            return output;
        }
    }
}
