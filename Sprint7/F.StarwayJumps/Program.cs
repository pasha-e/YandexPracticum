using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class F
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        

        var nk = ReadList();

        var count = CalcWaysCount(nk[0], nk[1]);

        writer.WriteLine(count);

        reader.Close();
        writer.Close();
    }

    private static long CalcWaysCount(int n, int k)
    {
        var module = 1000000000 + 7;

        int count = 0;

        //лесенка считается не с нуля )

        long[] fibModules = new long[n];

        fibModules[0] = 1;
        fibModules[1] = 1;

        for (int i = 2; i < n; i++)
        {
            long temp = 0;
            for (int j = 1; j <= k; j++)
            {
                if (j > i)
                    break;

                temp += fibModules[i - j];
            }

            fibModules[i] = temp % module;

            //fibModules[i] = (fibModules[i - 1] + fibModules[i - 2] + fibModules[i - 3]) % module;
        }

        return fibModules[n-1];
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
6 3
13

7 7
32

2 2
1

62 44
535806680


79 34
470472762

 */
