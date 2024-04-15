using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class G
{
    private static TextReader reader;
    private static TextWriter writer;

    public static List<int> CountingSort(List<int> array, int k)
    {
        int[] countedValues = new int[k];
        foreach (int value in array)
        {
            countedValues[value]++;
        }

        int index = 0;

        for (int value = 0; value < k; value++)
        {
            for (int amount = 0; amount < countedValues[value]; amount++)
            {
                array[index] = value;
                index++;
            }
        }
        return array;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        var list = ReadList();

        PrintList(CountingSort(list,3));

        reader.Close();
        writer.Close();
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