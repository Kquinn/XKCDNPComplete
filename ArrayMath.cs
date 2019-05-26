using System;

namespace NP_CompleteOrder
{
    public class ArrayMath
    {
        public static decimal MultiplyArrays(int[] counterArray,decimal[] valueArray)
        {
            decimal output = 0;
            for (int position = 0; position < counterArray.Length; position++)
            {
                output += (counterArray[position]) * valueArray[position];
            }
            return output;
        }
    }
}