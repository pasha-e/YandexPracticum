using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class G
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());


        var m = ReadInt(); // сумма

        var n = ReadInt(); // число номиналов

        var coins = ReadList();

        int summ = GetMaxSumm(m, n, coins);

        writer.WriteLine(summ);

        reader.Close();
        writer.Close();
    }

    //https://www.youtube.com/watch?v=GrG1u1xbqhs&ab_channel=EvgeniyMalov
    private static int GetMaxSumm(int m, int n, List<int> coins)
    {
        int[,] dp = new int[n+1, m + 1];

        //dp[i][j] - число способов набрать сумму j, используя первые i монет

        //базовый случай
        // вернуть 0 монет можно только одним способом - ничего не возвращать
        for (int i = 1; i <= n; i++)
            dp[i, 0] = 1;

        // dp[s][n] = dp[s][n - max(s)] + dp[s-max[s]][n]

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (j - coins[i - 1] >= 0)
                    dp[i, j] = dp[i, j - coins[i-1]] + dp[i - 1, j];
                else
                {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }

        return dp[n, m];
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

 */