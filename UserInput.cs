using System;

namespace NP_CompleteOrder
{
    public class UserInput
    {
        public static double GetSpendTotal(double defaultSpendTotal)
        {
            double spendTotal = 0;
            string userInput = null;
            do
            {
                Console.Write($"How much would you like to spend? [${string.Format("{0:#.00}", defaultSpendTotal)}]:");
                userInput = Console.ReadLine();
            } while (userInput != "" && !double.TryParse(userInput, out spendTotal));

            if (spendTotal == 0)
            {
                spendTotal = defaultSpendTotal;
            }
            return spendTotal;
        }
    }
}
