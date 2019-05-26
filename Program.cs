using System;
using System.Collections.Generic;

namespace NP_CompleteOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<decimal, string> menu = new SortedList<decimal, string>
            {
                {2.15m, "Mixed Fruit"},
                {2.75m, "French Fries"},
                {3.35m, "Side Salad"},
                {3.55m, "Hot Wings"},
                {4.20m, "Mozzarella Sticks"},
                {5.80m, "Sampler Plate"}
            };

            decimal defaultSpendingTotal = 15.05m;
            
            DisplayInformation.Menu(menu);
   
            decimal spendTotal = UserInput.GetSpendTotal(defaultSpendingTotal);         

            Console.WriteLine($"Spend exactly ${string.Format("{0:#.00}", spendTotal)}:\n");



            //var solutions = NCompleteProblem.Solve(menu, spendTotal);
            var solutions = NCompleteProblem.OptimizedSolve(menu, spendTotal);

            if (solutions.Count == 0)
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
