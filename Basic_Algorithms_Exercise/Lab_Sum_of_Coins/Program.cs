using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        int[] availableCoins = Console.ReadLine()
            .Split(new string[] { "Coins:", ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        string[] targetSumArr = Console.ReadLine()
            .Split()
            .ToArray();

        int targetSum = int.Parse(targetSumArr[1]);

        Dictionary<int, int> selectedCoins = ChooseCoins(availableCoins, targetSum);

        int receivedSum = 0;

        foreach (var coin in selectedCoins)
        {
            receivedSum += coin.Key * coin.Value;
        }

        if (receivedSum != targetSum)
        {
            Console.WriteLine("Error");
        }
        else
        {
            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");

            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        List<int> sortedCoins = coins.OrderByDescending(x => x).ToList();
        Dictionary<int, int> result = new Dictionary<int, int>();
        int index = 0;
        int currentSum = 0;

        while (currentSum < targetSum && index < sortedCoins.Count)
        {
            int curCoin = sortedCoins[index];
            int remainingSum = targetSum - currentSum;
            int coinToTake = remainingSum / curCoin;
            if (coinToTake > 0)
            {
                result.Add(curCoin, coinToTake);

                int sumPerCoin = curCoin * coinToTake;
                currentSum += sumPerCoin;
            }
            index++;
        }
        return result;
    }
}