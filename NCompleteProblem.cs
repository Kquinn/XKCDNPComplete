using System.Collections.Generic;
using System.Linq;

namespace NP_CompleteOrder
{
    public class NCompleteProblem
    {
        public static List<int[]> Solve(SortedList<decimal, string> menu, decimal spendTotal)
        {

            var baseNArray = BaseNIntegerArray.CreateArray(menu.Keys.ToArray(), spendTotal);
            var x = baseNArray;

            List<int[]> output = new List<int[]>();
            List<int> workingSet = new List<int>();

            long iterationLimit = BaseNIntegerArray.GetLimit(baseNArray);

            while (iterationLimit >= 0)
            {

                workingSet = BaseNIntegerArray.GetPosition(baseNArray,iterationLimit).ToList();

                decimal sum = 0;

                for (int position =0; position< workingSet.Count;position++)
                {
                    decimal temp = ((decimal)workingSet[position]) * menu.Keys[position];
                    sum += temp;
                    if(sum>spendTotal)
                    {
                        position = workingSet.Count;//skip this iteration if the sum is already too high
                    }
                }

                if (sum == spendTotal || ((sum<spendTotal) && ((spendTotal - sum) % menu.Keys[0]) == 0))
                {
                    workingSet[0] += (int)((spendTotal - sum) / menu.Keys[0]);
                    bool exists = false;
                    foreach (var existingArray in output)
                    {
                        exists = Enumerable.SequenceEqual(workingSet, existingArray); //check if this solution is unique
                        if(exists)
                        {
                            break;
                        }
                    }
                    if (!exists)
                    {
                        output.Add(workingSet.ToArray());//add it to the list
                    }
                }

                workingSet.Clear();
                iterationLimit--;
            }
            
            return output;
        }


        public static List<int[]> OptimizedSolve(SortedList<decimal, string> menu, decimal spendTotal)
        {
            var valueArray = menu.Keys.ToArray();
            var baseNArray = BaseNIntegerArray.CreateArray(valueArray, spendTotal);
            var counterArray = ZeroArray.Create(baseNArray.Length);

            List<int[]> output = new List<int[]>();

            while (!counterArray.Equals(baseNArray))
            {
                
                decimal arrayProduct = ArrayMath.MultiplyArrays(counterArray,valueArray);
                if(arrayProduct>spendTotal)
                {
                    counterArray = ArrayCounter.SkipToNextValidArray(counterArray, baseNArray, valueArray, spendTotal);
                    //check if we can optimize
                }
                else
                {
                    if ((arrayProduct < spendTotal) && ((spendTotal - arrayProduct) % valueArray[0]) == 0)
                    {
                        counterArray[0] += (int)((spendTotal - arrayProduct) / valueArray[0]);
                        arrayProduct = ArrayMath.MultiplyArrays(counterArray, valueArray);
                    }

                    if (arrayProduct == spendTotal)
                    {
                        bool exists = false;
                        foreach (var existingArray in output)
                        {
                            exists = Enumerable.SequenceEqual(counterArray, existingArray); //check if this solution is unique
                            if (exists)
                            {
                                break;
                            }
                        }
                        if (!exists)
                        {
                            output.Add(counterArray.ToArray());//add it to the list
                        }
                    }
                    counterArray = ArrayCounter.Increment(counterArray, baseNArray);
                }
                
                
                
            }

            return output;
        }
    }
}