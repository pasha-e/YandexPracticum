using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class H
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        var list = ReadList();

        InsertionSortByComparator(list, Compare);

        reader.Close();
        writer.Close();
    }

    static void InsertionSortByComparator(List<string> array, Func<string, string, bool> greater)
    {
        for (int i = 1; i < array.Count; i++)
        {
            var itemToInsert = array[i];

            int j = i;

            while (j > 0 && greater(itemToInsert, array[j - 1]))
            {
                array[j] = array[j - 1];
                j--;
            }
            array[j] = itemToInsert;
        }

        foreach (var item in array)
        {
            writer.Write(item);
        }
    }

    // функция-компаратор
    static bool Compare(string first, string second)
    {
        int firstInt = Convert.ToInt32(first + second);
        int secondInt = Convert.ToInt32(second + first);

        if (firstInt > secondInt)
            return true;

        return false;
    }

    private static List<string> ReadList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}