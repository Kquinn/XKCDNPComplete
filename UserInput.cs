using System;

namespace NP_CompleteOrder
{
    public class UserInput
    {
        public static decimal GetSpendTotal(decimal defaultSpendTotal)
        {
            decimal spendTotal = 0;
            string userInput = null;
            do
            {
                Console.Write($"How much would you like to spend? [${string.Format("{0:#.00}", defaultSpendTotal)}]:");
                userInput = Console.ReadLine();
            } while (userInput != "" && !decimal.TryParse(userInput, out spendTotal));

            if (spendTotal == 0)
            {
                spendTotal = defaultSpendTotal;
            }
            return spendTotal;
        }
    }
}
