using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class D
{
    private static TextReader reader;
    private static TextWriter writer;

    private static List<string> _color = new List<string>();
    static List<int> previous = new ();
    static List<int> distance = new ();

    private static Dictionary<int, List<int>> _map = new();



    private static void CreateAdjacencyList(int n, List<(int, int)> edgesList)
    {
        foreach (var edge in edgesList)
        {
            if (!_map.ContainsKey(edge.Item1))
                _map.Add(edge.Item1, new List<int>());

            _map[edge.Item1].Add(edge.Item2);

            if (!_map.ContainsKey(edge.Item2))
                _map.Add(edge.Item2, new List<int>());

            _map[edge.Item2].Add(edge.Item1);
        }

        foreach (var pair in _map)
        {
            pair.Value.Sort();
        }
    }

    static void MainBFS(int n, int startVertex)
    {
        for (int i = 0; i < n; i++)
        {
            _color.Add("white");
        }

        for (int i = 0; i <= n; i++)
        {
            distance.Add(0);
            previous.Add(0);
        }

        var vertexes = BFS(startVertex, GetOutgoingEdges);

        foreach (var v in vertexes)
        {
            writer.Write($"{v} ");
        }
    }

    static List<int> BFS(int startVertex, Func<int, List<int>> outgoingEdges)
    {
        // Создадим очередь вершин и положим туда стартовую вершину.
        Queue<int> planned = new Queue<int>();
        planned.Enqueue(startVertex);
        _color[startVertex-1] = "gray";
        distance[startVertex] = 0;

        List<int> vertexResult = new();

        while (planned.Count > 0)
        {
            int u = planned.Dequeue();  // Возьмём вершину из очереди.

            vertexResult.Add(u);

            var edges = outgoingEdges(u);

            if (edges == null)
                break;

            foreach (int v in edges)
            {
                if (_color[v-1] == "white")
                {
                    // Серые и чёрные вершины уже
                    // либо в очереди, либо обработаны.
                    distance[v] = distance[u] + 1;
                    previous[v] = u;
                    _color[v-1] = "gray";
                    planned.Enqueue(v);  // Запланируем посещение вершины.
                }
            }
            _color[u-1] = "black";  // Теперь вершина считается обработанной.
        }

        return vertexResult; 
    }

    private static List<int> GetOutgoingEdges(int i)
    {
        if (_map.ContainsKey(i))
            return _map[i];
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

        var s = ReadInt();

        CreateAdjacencyList(nm[0], edges);

        MainBFS(nm[0], s);

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

4 4
1 2
2 3
3 4
1 4
3

3 2 4 1 



2 1
2 1
1

1 2


1 0
1

1

 */