using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class D
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var module = 1000000000 + 7;

        var n = ReadInt();

        CalcFibByModule(n, module);

        reader.Close();
        writer.Close();
    }

    private static void CalcFibByModule(int n, int module)
    {
        int[]  fibModules = new int[n+1];

        fibModules[0] = 1;
        fibModules[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            fibModules[i] = (fibModules[i-1] + fibModules[i - 2]) % module;
        }

        writer.WriteLine(fibModules[n]);

    }


    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}

/*
5
8

2
2

10
89
 */