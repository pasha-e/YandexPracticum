using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

public class H
{
    private static TextReader reader;
    private static TextWriter writer;

    
    private static Dictionary<int, List<int>> map = new();

    private static void CreateAdjacencyList(int n, List<(int, int)> edgesList)
    {
        foreach (var edge in edgesList)
        {
            if (!map.ContainsKey(edge.Item1))
                map.Add(edge.Item1, new List<int>());

            map[edge.Item1].Add(edge.Item2);

        }

        foreach (var pair in map)
        {
            pair.Value.Sort();
        }
    }

    static int _time = -1;
    static List<int?> _entry = new List<int?>();
    static List<int?> _leave = new List<int?>();
    static List<string> _color = new List<string>();

    static void MainDFS(int n, int startVertex)
    {
        for (int i = 0; i < n; i++)
        {
            _color.Add("white");
            _entry.Add(null);
            _leave.Add(null);
        }

        DFS(startVertex);

        for (int i = 0; i < n; i++)
            writer.WriteLine($"{_entry[i]} {_leave[i]}");
    }

    static void DFS(int v)
    {
        _time += 1;  // При входе в вершину время (номер шага) увеличивается.
        _entry[v-1] = _time;  // Запишем время входа.
        _color[v-1] = "gray";

        var outgoingEdges = GetOutgoingEdges(v);
        if (outgoingEdges != null)
        {
            foreach (int w in outgoingEdges)
            {
                if (_color[w - 1] == "white")
                {
                    DFS(w);
                }
            }
        }

        _time += 1;  // Перед выходом из вершины время снова обновляется.
        _leave[v - 1] = _time;  // Запишем время выхода.
        _color[v - 1] = "black";
    }

    private static IEnumerable<int> GetOutgoingEdges(int i)
    {
        if (map.ContainsKey(i))
            return map[i];
        return null;
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


        CreateAdjacencyList(nm[0], edges);

        MainDFS(nm[0], 1);

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

/*

 */