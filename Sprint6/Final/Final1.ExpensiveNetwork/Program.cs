/*
https://contest.yandex.ru/contest/25070/run-report/115153537/
 */
/*
     -- ПРИНЦИП РАБОТЫ --

    Решение реализовано на алгоритме Прима на приоритетной очереди
    Отличие - нам надо брать не минималнео ребро, а наоборот, максимальное.
    Для этого будем инвертировать вес ребра.

    Добавляем вершины в остов. ПРи добавлении проводим проверку  исходящих рёбер из этой вершины на отсутсиве вершин этих ребёр в списке вешин уже лежащих в остове.
    Если ребро новое, то добавляем  есть в приоритетныу очередь (кучу),  критерием приоритета будет служить отрицательный вес ребра , так как при  получении элемента с кучи нам будет нужен максимальный элемент

    Примечание :  в .net  куча реализована в структуре PriorityQueue, поэтому в описании слова куча и очередь можно считать равнозначными

    (можно было б переопределить IComparer в PriorityQueue, но здесь сравнение простое, проще домножить на -1)

    В начале  на вход подаём граф, и начинаем обход с первой вершины. Зачем циклично  берем приоритетный (максимальный у нас) элемент с очереди, пока очередь не пуста и пока не все вершины добавлены
    Проверяем что этой вершины нет в списке добавленных в остов вершин,  суммируем вес ребра  накапливаемым значением (не забыв взять по модулю), и добавляем вершину в остов.

    По окончании проверим все ли  вершины обработаы, если да - выводим накопленное значение веса, если нет значит граф имеет несвязные вершины.
     
     -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
    Если хранить рёбра, исходящие из уже собранного подмножества остова в приоритетной очередри, 
    то выбирать ребро с оптимальный весом будет легко. 
    Если вместе с ребром в подграф добавляется новая вершина, то это ребро добавляется в остов. 
    Если ребро соединяет две вершины, уже присутствующее в подмножестве остова, мы отбрасываем его из дальнейшего рассмотрения и из кучи в том числе.

    O(E*log V), где E количество рёбер в графе, а V — количество вершин.
    
        
     -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
    
    основная памать уходит на построение списка смежности. O(V * E)
    и организация приоритетной очередина куче O(n), n = V

    https://habr.com/ru/companies/skbkontur/articles/666018/
    
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
            //граф неориентированный - добавим в обе стороны

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
                _pqEdges.Enqueue(edge, -weight); // нам надо "обратная" приоритезация, поэтому домноим вес на -1
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

        //начаало постоения
        AddVertex(1, _graph[1], ref added);

        //пока не все ребра добавлены и в куче есть элементы
        while ( !CheckAllAdded(added) && _pqEdges.Count > 0)
        {
            //получаем приоритетный элемент
            if (!_pqEdges.TryDequeue(out var edge, out var priority))
                break;

            if (added[edge]) continue;

            maxPathTree += Math.Abs(priority);

            //добавляем вершину в остов
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