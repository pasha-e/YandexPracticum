using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class J
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        var list = ReadList();

        BubbleSort(n, list);

        reader.Close();
        writer.Close();
    }

    private static void BubbleSort(int n, List<int> list)
    {
        for (int j = 0; j < n-1; j++)
        {
            bool needSort = false;

            for (int i = 0; i < n - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    (list[i], list[i + 1]) = (list[i + 1], list[i]);
                    needSort = true;
                }
            }

            if (!needSort && j != 0)
                break;

            PrintList(list);
        }
    }

    private static void PrintList(List<int> list)
    {
        foreach (var elem in list)
            writer.Write(elem + " ");

        writer.WriteLine();
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