using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;

public class A
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        var prices = ReadList();

        var profit = CalcBestPrice(prices);

        writer.WriteLine(profit);
        
        reader.Close();
        writer.Close();
    }

    private static int CalcBestPrice(List<int> prices)
    {
        var bestProfit = 0;

        for (int i = 0; i < prices.Count-1; i++)
        {
            if (prices[i] < prices[i + 1])
                bestProfit += prices[i+1] - prices[i];
        }

        return bestProfit;
    }


    private static List<int> ReadList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}

/*

6
7 1 5 3 6 4

7

5
1 2 3 4 5

4

6
1 12 12 16 1 8

22
 */
