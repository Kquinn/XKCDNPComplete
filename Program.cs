using System;
using System.Collections.Generic;

namespace NP_CompleteOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<double,string> menu = new SortedList<double,string>
            {
                {2.15, "Mixed Fruit"},
                {2.75, "French Fries"},
                {3.35, "Side Salad"},
                {3.55, "Hot Wings"},
                {4.20, "Mozzarella Sticks"},
                {5.80, "Sampler Plate"}
            };

            double defaultSpendingTotal = 15.05;
            
            DisplayInformation.Menu(menu);
   
            double spendTotal = UserInput.GetSpendTotal(defaultSpendingTotal);         

            Console.WriteLine($"Spend exactly ${string.Format("{0:#.00}", spendTotal)}:\n");

            var solutions = NCompleteProblem.Solve(menu, spendTotal);
            if(solutions.Count == 0)
            {
                Console.WriteLine("No valid solutions.\n");
            }
            else
            {
                DisplayInformation.Solutions(solutions, menu);
            }
            
            Console.Write("\n\nTask Complete\nPress Enter to Close");
            Console.ReadLine();
        }   
    }
}
