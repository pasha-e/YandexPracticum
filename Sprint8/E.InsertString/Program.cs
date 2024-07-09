using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class E
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var str = reader.ReadLine();

        var n = ReadInt();

        List<(string, int)> substrings = new();

        for (int i = 0; i < n; i++)
        {
            var data = ReadList();

            substrings.Add((data[0], Convert.ToInt32(data[1])));
        }

        string res = InsertStrings(str, substrings);

        writer.WriteLine(res);

        reader.Close();
        writer.Close();
    }

    private static string InsertStrings(string? str, List<(string, int)> substrings)
    {
        substrings.Sort(StrComparer);

        StringBuilder result = new StringBuilder(String.Empty);

        int shift =0;

        foreach (var substring in substrings)
        {
            var tmp = str.Substring(shift, substring.Item2-shift);
            result.Append(tmp);
            result.Append(substring.Item1);

            shift = substring.Item2;
        }

        if (shift < str.Length)
            result.Append(str.Substring(shift, str.Length - shift));

        return result.ToString();
    }

    private static int StrComparer((string, int) x, (string, int) y)
    {
        return x.Item2.CompareTo(y.Item2);
    }

    private static List<string> ReadList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}

/*
 
abacaba
3
queue 2
deque 0
stack 7

dequeabqueueacabastack


kukareku
2
p 1
q 2

kpuqkareku

 */