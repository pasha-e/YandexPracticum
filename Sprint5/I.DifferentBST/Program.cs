/*
 https://ru.wikipedia.org/wiki/%D0%A7%D0%B8%D1%81%D0%BB%D0%B0_%D0%9A%D0%B0%D1%82%D0%B0%D0%BB%D0%B0%D0%BD%D0%B0
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class I
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        writer.WriteLine(CalculateNumOfBST(n));

        reader.Close();
        writer.Close();
    }

    private static int CalculateNumOfBST(int n)
    {
        if(n == 0)
            return 1;

        int res = 0;

        /*for (int i = 1; i < n + 1; i++)
        {
            res += CalculateNumOfBST(i - 1) * CalculateNumOfBST(n - i);
        }*/
        for (int i = 0; i <= n-1 ; i++)
        {
            res += CalculateNumOfBST( i ) * CalculateNumOfBST(n - 1 - i);
        }

        return res;
    }


    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}