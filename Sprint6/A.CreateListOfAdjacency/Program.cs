using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class A
{
    private static TextReader reader;
    private static TextWriter writer;

    private static void CreateAdjacencyList(int n, List<(int, int)> edgesList)
    {
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

        for(int i = 1; i <= n; i++)
            map.Add(i, new List<int>());


        foreach (var edge in edgesList)
        {
            map[edge.Item1].Add(edge.Item2);
        }

        foreach (var pair in map)
        {
            pair.Value.Sort();
        }

        foreach (var pair in map)
        {
            var count = pair.Value.Count;

            string result = $"{count}";

            if (count > 0)
            {
                foreach (var value in pair.Value)
                {
                    result += $" {value}";
                }
            }

            writer.WriteLine(result);

        }
    }

    private static void CreateAdjacencyList2(int n, List<(int, int)> edgesList)
    {
        List<List<int>> list = new ();

        for (int i = 0; i < n; i++)
            list.Add( new List<int>());


        foreach (var edge in edgesList)
        {
            list[edge.Item1-1].Add(edge.Item2);
        }

        foreach (var data in list)
        {
            data.Sort();
        }

        foreach (var data in list)
        {
            var count = data.Count;

            string result = $"{count}";

            if (count > 0)
            {
                foreach (var value in data)
                {
                    result += $" {value}";
                }
            }

            writer.WriteLine(result);

        }
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var nm = ReadList();


        var edges  = new List<(int,int)> ();

        for (int i = 0; i < nm[1]; i++)
        {
            var uv = ReadList();

            edges.Add((uv[0], uv[1]));
        }

        CreateAdjacencyList(nm[0], edges);

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


1 3 
1 3 
0 
0 
1 2 
 */