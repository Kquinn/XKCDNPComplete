using System;
using System.Collections.Generic;

namespace NP_CompleteOrder
{
    public class BaseNIntegerArray
    {

        public static int[] CreateArray(decimal[] inputArray, decimal total)
        {
            List<int> output = new List<int>();

            foreach (var item in inputArray)
            {
                decimal x = total/item;
                output.Add((int)x.RoundUp());
            }

            return output.ToArray();

        }

        public static long GetLimit(int[] inputArray)
        {
            long output = 1;
            foreach (var value in inputArray)
            {
                output *= value;
            }
            return output;
        }

        public static int[] GetPosition(int[] inputArray, long index)
        {
            List<int> output = new List<int>();

            for(int pointer = 0; pointer < inputArray.Length; pointer++)
            {
                if (index < 1)
                {
                    output.Add(0);
                }
                else
                {
                    output.Add((int)index % inputArray[pointer]);
                }

                index = (long)Math.Floor((double)index / inputArray[pointer]);                
            }
            /*
            foreach (var item in inputArray)
            {
                output.Add((int)index % item);
                index = (long)Math.Floor((double)index / item);
                
                if(index<1)
                {
                    break;
                }
            }*/
            
            return output.ToArray();
        }


        public static int[] Convert(long counter, int numberBase)
        {
            List<int> output = new List<int>();
            while (counter > 0)
            {
                output.Add((int)counter % numberBase);
                counter = (long)Math.Floor((double)counter / numberBase);
            }

            return output.ToArray();
        }
    }
}
