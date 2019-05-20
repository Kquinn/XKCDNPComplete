using System;
using System.Collections.Generic;
using System.Linq;

namespace NP_CompleteOrder
{
    public class DisplayInformation
    {
        public static void Menu(SortedList<double, string> menu)
        {
            Console.WriteLine("\n\tMenu");
            Console.WriteLine("----------------------------");
            foreach (var menuItem in menu)
            {
                Console.WriteLine($"  ${string.Format("{0:#.00}", menuItem.Key)}\t{menuItem.Value}");
            }
            Console.WriteLine("----------------------------\n");
        }

        public static void Solutions(List<double[]> solutionList, SortedList<double, string> menu)
        {
            int solutionNumber = 1;
            foreach (var solution in solutionList)
            {
                Console.WriteLine($"Solution {solutionNumber}:");
                foreach (var menuitem in menu)
                {
                    if (solution.Contains(menuitem.Key))
                    {
                        int count = solution.Count(x => x == menuitem.Key);
                        Console.WriteLine($"\t{count}x {menuitem.Value}");
                    }
                }
                Console.WriteLine();
                solutionNumber++;
            }
        }
    }
}
