using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;

public class E
{
    private static TextReader reader;
    private static TextWriter writer;

    private static List<int> _color = new ();

    private static Dictionary<int, List<int>> _map = new();

    private static int _componentCount = 1;

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
            //pair.Value.Reverse();
        }
    }

    static void MainDFS(int n)
    {
        for (int i = 0; i < n; i++)
            _color.Add(-1);

        List<List<int>> arrVertexesList = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            var vertexesList = DFS(i+1); // +1 чтобы не сбить нумерацию .  можно и цикл вести от 1 до n]
            
            if(vertexesList.Count > 0)
                arrVertexesList.Add(vertexesList);
        }

        //вывод
        writer.WriteLine(arrVertexesList.Count);
        foreach (var vertexes in arrVertexesList)
        {
            vertexes.Sort();

            foreach (var vertex in vertexes)
            {
                writer.Write($"{vertex} ");
            }
            writer.WriteLine();
        }
    }

    static List<int> DFS(int startVertex)
    {
        var result = new List<int>();

        Stack<int> stack = new Stack<int>();
        stack.Push(startVertex); // Добавляем стартовую вершину в стек.

        while (stack.Count > 0) // Пока стек не пуст:
        {

            int v = stack.Pop();

            if (_color[v - 1] == -1)
            {
                result.Add(v);

                _color[v - 1] = _componentCount;
                stack.Push(v);

                var outgoingEdges = GetOutgoingEdges(v);
                if (outgoingEdges == null)
                    break;

                foreach (int w in outgoingEdges)
                {
                    // Для каждого исходящего ребра (v, w):
                    if (_color[w - 1] == -1)
                    {
                        stack.Push(w);
                    }
                }
            }

            _componentCount ++ ;
        }

        return result;
    }

    private static IEnumerable<int> GetOutgoingEdges(int i)
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

        CreateAdjacencyList(nm[0], edges);

        MainDFS(nm[0]);

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
6 3
1 2
6 5
2 3

3
1 2 3 
4 
5 6 



2 0

2
1 
2 



4 3
2 3
2 1
4 3

1
1 2 3 4


10 7
2 1
5 8
5 3
9 6
1 9
6 10
7 2

3
1 2 6 7 9 10 
3 5 8 
4 



10 11
6 8
4 8
9 7
3 7
4 6
3 1
9 1
5 7
2 6
3 5
8 10

2
1 3 5 7 9 
2 4 6 8 10 


10 7
3 1
4 5
5 8
6 4
4 9
5 2
4 10

3
1 3 
2 5 8 4 10 9 6 
7 

 */