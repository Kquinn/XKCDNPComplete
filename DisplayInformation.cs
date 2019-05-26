using System;
using System.Collections.Generic;
using System.Linq;

namespace NP_CompleteOrder
{
    public class DisplayInformation
    {
        public static void Menu(SortedList<decimal, string> menu)
        {
            Console.WriteLine("\n\tMenu");
            Console.WriteLine("----------------------------");
            foreach (var menuItem in menu)
            {
                Console.WriteLine($"  ${menuItem.Key}\t{menuItem.Value}");
            }
            Console.WriteLine("----------------------------\n");
        }

        public static void Solutions(List<int[]> solutionList, SortedList<decimal, string> menu)
        {
            int solutionNumber = 1;
            foreach (var solution in solutionList)
            {
                Console.WriteLine($"Solution {solutionNumber}:");
                for (int x = 0; x< solution.Length; x++)
                {
                    if(solution[x] != 0)
                    {
                        Console.WriteLine($"\t{solution[x]}x {menu.Values[x]}");
                    }
                }
                Console.WriteLine();
                solutionNumber++;
            }
        }
    }
}
