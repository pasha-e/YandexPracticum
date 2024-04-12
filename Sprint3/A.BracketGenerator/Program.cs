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

        var n =ReadInt();

        GenerateBrackets(n);

        reader.Close();
        writer.Close();
    }

    private static void GenerateBrackets(int n)
    {
        var res = Generate(n * 2, 0, "", new List<string>());

        foreach (var line in res)
        {
            writer.WriteLine(line);
        }
    }

    private static List<string> Generate(int n, int open, string prefix, List<string> list)
    {
        if (n == 1)
        {
            list.Add(prefix + ")");

            return list;
        }

        if (n > open)
        {
            list = Generate(n - 1, open + 1, prefix + "(", list);
        }

        if (open > 0)
        {
            list = Generate(n - 1, open - 1, prefix + ")", list);
        }

        return list;

    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }

}
