using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class B
{
    private static TextReader reader;
    private static TextWriter writer;

    private static void CreateAdjacencyMatrix(int n, List<(int, int)> edgesList)
    {
        int[,] matrix = new int[n,n];

        for(int i=0; i < n; i++)
            for (int j = 0; j < n; j++)
                matrix[i,j] = 0;


        foreach (var edge in edgesList)
        {
            matrix[edge.Item1-1, edge.Item2-1] = 1;
        }


        for (int i = 0; i < n; i++)
        {
            string line = String.Empty;

            for (int j = 0; j < n; j++)
            {
                line += $"{matrix[i,j]} ";
            }

            writer.WriteLine(line);
        }
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var nm = ReadList();


        var edges = new List<(int, int)>();

        for (int i = 0; i < nm[1]; i++)
        {
            var uv = ReadList();

            edges.Add((uv[0], uv[1]));
        }

        CreateAdjacencyMatrix(nm[0], edges);

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

/*

5 3
1 3
2 3
5 2


0 0 1 0 0 
0 0 1 0 0 
0 0 0 0 0 
0 0 0 0 0 
0 1 0 0 0 
 */