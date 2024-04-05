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

        
        //row
        var n = ReadInt();
        //column
        var m = ReadInt();

        List<int> lineMatrix = new List<int>();

        for (int i = 0; i < n; i++)
        {
            var list = ReadList();

            foreach (var elem in list)
                lineMatrix.Add(elem);           
        }

        PrintNewMatrix(lineMatrix, n , m);

        reader.Close();
        writer.Close();
    }

    private static void PrintNewMatrix(List<int> lineMatrix, int row, int column)
    {
        for (int j = 0; j < column; j++)
        {
            for (int i = 0; i < row; i++)
            {
                writer.Write($"{lineMatrix[i * column + j]} ");
            }

            writer.WriteLine();
        }
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