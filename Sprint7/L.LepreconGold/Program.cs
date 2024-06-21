using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class L
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());


        var nm = ReadList();

        var weights = ReadList();

        int maxWeight = GetMaxWeight(nm[0], nm[1], weights);

        writer.WriteLine(maxWeight);

        reader.Close();
        writer.Close();
    }
    /*
    private static int GetMaxWeight(int n, int m, List<int> weights)
    {
        int[,] dp = new int[n,m];

        for(int i  = 0; i < n; i++)
            dp[i, 0] = 0;
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < m; j++)
            {
                var byLine = i - 1 < 0 ? 0 : i - 1;
                var byRow = j - weights[i] <= 0 ? 0 : j - weights[i];


                //dp[i, j] = Max(dp[i - 1, j], cost[i] + dp[i - 1, j - weight[i]]);

                var max = Max(dp[byLine, j], weights[i] + dp[byLine, byRow]);

                dp[i, j] = max;
            }
        }

        return dp[n-1,m-1];
    }
    */

    private static int GetMaxWeight(int n, int m, List<int> weights)
    {
        int[,] dp = new int[n, m+1];

        for (int i = 0; i < n; i++)
            dp[i, 0] = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < m+1; j++)
            {
                var maxWeight = 0;

                var prevWeight = 0;

                if (j == weights[i])
                {
                    maxWeight = weights[i];
                }
                else
                {
                    if (j > weights[i])
                    {
                        prevWeight = 0;

                        if(i >=1)
                            prevWeight = dp[i-1, j - weights[i]];

                        maxWeight = weights[i] + prevWeight;
                    }
                }

                prevWeight = 0;

                if (i >= 1)
                    prevWeight = dp[i - 1, j];

                dp[i, j] = Max(prevWeight, maxWeight);
            }
        }

        return dp[n - 1, m ];
    }

    static int Max(int a, int b)
    {
        if (a > b)
            return a;

        return b;
    }

    private static List<int> ReadList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
    }
}

/*
5 15
3 8 1 2 5

15

5 19
10 10 7 7 4

18
 */