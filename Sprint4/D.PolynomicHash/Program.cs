using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class D
{
    private static TextReader reader;
    private static TextWriter writer;


    private static long Modulus(long a, long b)
    {
        long c = (long)Math.Floor((double)a / b);

        return a - c * b;
    }

    private static long GetHash(string sourceStr, int p, int m)
    {
        long hash = 0;

        long powerP = 1;

        foreach (var symb in sourceStr.Reverse())
        {
            hash = Modulus((hash + (int)symb * powerP), m);

            powerP = Modulus((powerP * p), m);
        }

        return hash;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var a = ReadInt();
        var m = ReadInt();

        string sampleStr = reader.ReadLine();

        writer.WriteLine(GetHash(sampleStr, a, m));

        reader.Close();
        writer.Close();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}

/*
 
123
100003
a
->97

123
100003
hash
->6080

123
100003
HaSH
->56156

 */