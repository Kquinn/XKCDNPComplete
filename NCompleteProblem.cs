using System.Collections.Generic;
using System.Linq;

namespace NP_CompleteOrder
{
    public class NCompleteProblem
    {
        public static List<double[]> Solve(SortedList<double, string> menu, double spendTotal)
        {
            int totalNumberOfMenuItems = menu.Keys.Count;
            List<double[]> output = new List<double[]>();
            List<double> workingSet = new List<double>();

            long iterationCounter = 0;

            while (true)
            {
                var iterationArray = BaseNToIntegerArray.Convert(iterationCounter, totalNumberOfMenuItems);

                if (iterationArray.Length > totalNumberOfMenuItems)
                {
                    break;
                }
                int position = 0;
                foreach (var menuItemIndex in iterationArray)
                {
                    for (int itemQuantity = 0; itemQuantity < menuItemIndex; itemQuantity++)
                    {
                        workingSet.Add(menu.Keys[position]);
                    }
                    position++;
                }
                while (workingSet.Sum() < spendTotal)
                {
                    workingSet.Add(menu.Keys[0]); //fill with first item until >= total
                }
                if (workingSet.Sum() == spendTotal)
                {
                    workingSet.Sort();
                    var sortedWorkingSet = workingSet.ToArray();
                    bool exists = false;
                    foreach (var existingArray in output)
                    {
                        exists = Enumerable.SequenceEqual(sortedWorkingSet, existingArray); //check if this solution is unique
                    }
                    if (!exists)
                    {
                        output.Add(sortedWorkingSet);//add it to the list
                    }
                }

                workingSet.Clear();
                iterationCounter++;
            }

            return output;
        }
    }
}
