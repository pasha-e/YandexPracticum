using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class E
{
    private static TextReader reader;
    private static TextWriter writer;

    private static int FindHouseNumber(int budget, List<int> list)
    {
        list.Sort();

        var count = 0;

        foreach (int price in list)
        {
            budget -= price;

            if (budget >= 0)
                count++;
            else
                break;
        }

        return count;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var param = ReadList();

        var list = ReadList();

        writer.WriteLine(FindHouseNumber(param[1], list));

        reader.Close();
        writer.Close();
    }

    private static List<int> ReadList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
    }
}