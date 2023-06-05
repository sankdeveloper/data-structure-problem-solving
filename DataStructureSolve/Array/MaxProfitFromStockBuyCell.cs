namespace ConsoleApp1.Array;

// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
public class MaxProfitFromStockBuyCell
{
    public static void Main1(string[] args)
    {
        var stocks = new int[] { 10, 2, 11, 20, 7, 50 };
        int maxProfit = 0;
        int minSoFar = stocks[0];

        for (int i = 1; i < stocks.Length; i++)
        {
            maxProfit = Math.Max(maxProfit, stocks[i] - minSoFar);
            minSoFar = Math.Min(minSoFar, stocks[i]);
        }

        Console.WriteLine($"Max Profit: {maxProfit}");
        Console.ReadKey();
    }
}