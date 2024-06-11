/*
https://contest.yandex.ru/contest/25070/run-report/115153537/
 */
/*
 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ExpensiveNetwork
{
    private const string NotCreateMST = "Oops! I did it again";

    private static TextReader reader;
    private static TextWriter writer;


    private static Dictionary<int, List<(int, int)>> _graph = new();

    private static PriorityQueue<int, int> _pqEdges = new();

    
    private static void CreateAdjacencyList(int n, List<(int, int, int)> edgesList)
    {
        for(int i = 1; i < n+1; i++) 
            _graph.Add(i, new List<(int, int)>());

        foreach (var edge in edgesList)
        {
            if (!_graph.ContainsKey(edge.Item1))
                _graph.Add(edge.Item1, new List<(int, int)>());

            _graph[edge.Item1].Add( (edge.Item2, edge.Item3) );

            if (!_graph.ContainsKey(edge.Item2))
                _graph.Add(edge.Item2, new List<(int, int)>());

            _graph[edge.Item2].Add( (edge.Item1, edge.Item3));
        }

    }

    private static void AddVertex(int vertex, List<(int, int)> graphEdges, ref List<bool> added)
    {
        added[vertex] = true;

        foreach (var (edge, weight) in graphEdges)
        {
            if (added[edge] == false)
                _pqEdges.Enqueue(edge, -weight);
        }
    }

    private static int? CreateNetwork(int n)
    {
        int maxPathTree = 0;

        List<bool> added = new();

        for (var i = 0; i < n; i++)
        { 
            added.Add(false);
        }

        added.Add(false);

        added[0] = true;


        AddVertex(1, _graph[1], ref added);

        while ( !CheckAllAdded(added) && _pqEdges.Count > 0)
        {
            if (!_pqEdges.TryDequeue(out var edge, out var priority))
                break;

            if (added[edge]) continue;

            maxPathTree += Math.Abs(priority);

            AddVertex(edge, _graph[edge], ref added);
        }

        return CheckAllAdded(added)? maxPathTree : null;
    }

    private static bool CheckAllAdded(List<bool> list)
    {
        foreach (var val in list)
        {
            if(val == false)
                return false;
        }

        return true;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var nm = ReadList();

        var weightEdges = new List<(int, int, int)>();

        for (int i = 0; i < nm[1]; i++)
        {
            var uvw = ReadList();

            weightEdges.Add((uvw[0], uvw[1], uvw[2]));
        }

        CreateAdjacencyList(nm[0], weightEdges);

        var maxPath = CreateNetwork(nm[0]);

        writer.WriteLine(!maxPath.HasValue ? NotCreateMST : $"{maxPath.Value}");


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

4 4
1 2 5
1 3 6
2 4 8
3 4 3

19

3 3
1 2 1
1 2 2
2 3 1

3


2 0

Oops! I did it again
 */