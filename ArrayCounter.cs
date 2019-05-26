using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP_CompleteOrder
{
    public class ArrayCounter
    {
        public static int[] Increment(int[] arrayToIncrement, int[] limitArray)
        {
            int length = arrayToIncrement.Length;
            arrayToIncrement[0]++;
            for(int i =0;i<length;i++)
            {
                if(arrayToIncrement[i] > limitArray[i])
                {
                    if(i+1==length)
                    {
                        return limitArray;
                    }
                    arrayToIncrement[i] = 0;
                    arrayToIncrement[i + 1]++;
                }
            }
            return arrayToIncrement;
        }

        public static int[] SkipToNextValidArray(int[] arrayToIncrement, int[] limitArray, decimal[] valueArray, decimal spendTotal)
        {
            int length = arrayToIncrement.Length;
            for (int i = 0; i < length; i++)
            {
                if (i + 1 == length)
                {
                    return limitArray;
                }
                arrayToIncrement[i] = 0;
                arrayToIncrement[i + 1]++;
                if(ArrayMath.MultiplyArrays(arrayToIncrement,valueArray) <= spendTotal)
                {
                    return arrayToIncrement;
                }   
            }
            return arrayToIncrement;
        }
    }
}
