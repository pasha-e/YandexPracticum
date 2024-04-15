using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class G
{
    private static TextReader reader;
    private static TextWriter writer;

    private static int FindBestTriangle(List<int> list)
    {
        list.Sort(CompareReverse);

        for (int i = 0; i < list.Count-2; i++)
        {
            if (list[i] < list[i + 1] + list[i + 2])
                return list[i] + list[i + 1] + list[i + 2];
        }

        return -1;
    }

    private static int CompareReverse(int x, int y)
    {
        return -x.CompareTo(y);
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        var list = ReadList( );

        writer.WriteLine( FindBestTriangle( list) );

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

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}