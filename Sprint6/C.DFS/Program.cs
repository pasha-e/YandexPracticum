using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

public class C
{
    private static TextReader reader;
    private static TextWriter writer;

    private static List<string> color = new List<string>();// { "white", "white", ...};

    private static Dictionary<int, List<int>> map = new();

    private static void CreateAdjacencyList(int n, List<(int, int)> edgesList)
    {
        //for

        foreach (var edge in edgesList)
        {
            if(!map.ContainsKey(edge.Item1))
                map.Add(edge.Item1, new List<int>());

            map[edge.Item1].Add(edge.Item2);

            if (!map.ContainsKey(edge.Item2))
                map.Add(edge.Item2, new List<int>());

            map[edge.Item2].Add(edge.Item1);
        }

        foreach (var pair in map)
        {
            pair.Value.Sort();
            pair.Value.Reverse();
        }
    }

    static void MainDFS(int n, int startVertex)
    {
        for(int i=0; i < n; i++) 
            color.Add("white");

        var res = DFS(startVertex);

        foreach (var value in res)
        {
            writer.Write($"{value} ");
        }
    }

    static List<int> DFS(int startVertex)
    {
        var result = new List<int>();

        Stack<int> stack = new Stack<int>();
        stack.Push(startVertex); // Добавляем стартовую вершину в стек.
        
        while (stack.Count > 0) // Пока стек не пуст:
        {
            // Получаем из стека очередную вершину.
            // Это может быть как новая вершина, так и уже посещённая однажды.
            int v = stack.Pop();

            if (color[v-1] == "white")
            {
                result.Add(v);

                // Красим вершину в серый. И сразу кладём её обратно в стек:
                // это позволит алгоритму позднее вспомнить обратный путь по графу.
                color[v-1] = "gray";
                stack.Push(v);

                // Теперь добавляем в стек все непосещённые соседние вершины,
                // вместо вызова рекурсии
                var outgoingEdges = GetOutgoingEdges(v);
                if (outgoingEdges == null)
                    break;

                foreach (int w in outgoingEdges)
                {
                    // Для каждого исходящего ребра (v, w):
                    if (color[w-1] == "white")
                    {
                        stack.Push(w);
                    }
                }
            }
            else if (color[v - 1] == "gray")
            {
                // Серую вершину мы могли получить из стека только на обратном пути.
                // Следовательно, её следует перекрасить в чёрный.
                color[v - 1] = "black";
            }
        }

        return result;
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

        var s = ReadInt();

        CreateAdjacencyList(nm[0], edges);

        MainDFS(nm[0], s);

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
3 1
2 3
1

1


1 0
1

1


4 4
3 2
4 3
1 4
1 2
3

3 2 1 4 


2 1
1 2
1

1 2
 */