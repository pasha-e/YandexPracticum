/*
 https://contest.yandex.ru/contest/25070/run-report/115207303/
 */
/*
     -- ПРИНЦИП РАБОТЫ --

     Смысл решения сводится к поиску циклов на орграфе

     СОгласно  условию - От одного города до другого можно проехать только по маршруту, состоящему исключительно из дорог типа R или только из дорог типа B.
     Значит, если  из города А в город Б ведёт как дорога ( или цепочка дорог) типа R так и типа B , то, если принять дороги R и В ребрами разной направленности, образуется цикл.
     В итоге , для определения оптимальности сети дорог необходимо построить граф и искать на нем циклы
        
     Принцип работы алгоритма:
        1)зачитать карту маршрута в граф, причем будем считать что дороги одного типа это одно направление ребер, а другого типа - обратное
        2)для каждой вершины этого графа запустим DFS (обход в глубину)
        3)если обнаружен цикл - значит карта не оптимальна, и есть разные маршруты

        Метод DFS
        необходимо реализовать сисему отметки посещённых узлов (городов). 
        Будем крашивтаь узлы в разные цветы. Белый - непосещённый город, Серый - посещённый, но не все пути из него проверены, Чёрный - посещённый и все пути проверены
        Если при обходе карты (графа)  мы  встретим серый (уже посещённый нами) город,  значит в графе есть цикл.  То есть, на карту есть  минимум пара городов, между которыми есть маршрут с разными типами полотна дороги.
        
        Значит по условию -  карта не является оптимальной
     
                
     
     -- ВРЕМЕННАЯ СЛОЖНОСТЬ --

        основная часть алгоритма это обработка DFS со спискми смежности
        Сложность такого алгоритма O(V + E) ,  где V - число вершин,  E - число рёбер
        
     -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
        
        основная памать уходит на построение списка смежности. O(V + E)
        и построение списка посещенных вершин O(V)
      
        https://stepik.org/lesson/277659/step/6
        https://neerc.ifmo.ru/wiki/index.php?title=%D0%98%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5_%D0%BE%D0%B1%D1%85%D0%BE%D0%B4%D0%B0_%D0%B2_%D0%B3%D0%BB%D1%83%D0%B1%D0%B8%D0%BD%D1%83_%D0%B4%D0%BB%D1%8F_%D0%BF%D0%BE%D0%B8%D1%81%D0%BA%D0%B0_%D1%86%D0%B8%D0%BA%D0%BB%D0%B0
        https://www.geeksforgeeks.org/detect-cycle-direct-graph-using-colors/
   */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public class Railroads
{
    private const string MapIsOptimise = "YES";
    private const string MapIsNotOptimise = "NO";

    private const char RoadTypeB = 'B';
    private const char RoadTypeR = 'R';

    private static TextReader reader;
    private static TextWriter writer;

    //private static Dictionary<int, List<int>> _graph = new();

    enum Colors
    {
        White = 0,
        Gray = 1,
        Black = 2,
    }


    /// <summary>
    /// заполнение списка смежности
    /// </summary>
    /// <param name="n"></param>
    /// <param name="mapList"></param>
    private static Dictionary<int, List<int>> CreateAdjacencyList(int n, List<string> mapList)
    {
        Dictionary<int, List<int>> graph = new();

        for (int i = 0; i < n; i++)
        {
            graph.Add(i, new List< int>());
        }

        for (int i = 0; i < n - 1; i++)
        {
            var map = mapList[i];
            for (int j = 0; j < map.Length; j++)
            {
                var roadType = map[j];

                switch (roadType)
                {
                    case RoadTypeB:
                        graph[i].Add(i + j + 1);
                        break;
                    case RoadTypeR:
                        graph[i + j + 1].Add(i);
                        break;
                    default:
                        //можно кинуть исключение.  хотя в примерах нет таких случаев
                        throw new Exception("wrong road type");
                }
            }
        }

        return graph;
    }


    private static void AnalyseMap(int n, List<string> mapList)
    {
        //построим список смежности
        var graph = CreateAdjacencyList(n, mapList);

        var res = CheckGraphToCycle(graph) ? MapIsNotOptimise : MapIsOptimise;

        writer.WriteLine(res);
    }


    /// <summary>
    /// проверка графа на наличие циклов
    /// </summary>
    /// <returns></returns>
    private static bool CheckGraphToCycle(Dictionary<int, List<int>> graph)
    {
        List<Colors> colors = new ();
        for(int i = 0; i < graph.Count; i++)
        {
            colors.Add(Colors.White);
        }

        for (int i = 0; i < graph.Count; i++)
        {
            if (CheckDFSToCycle(i, graph,  ref colors))
                return true;
        }

        return false; 

    }

    /// <summary>
    /// Проверка с помощью DFS на наличие циклов
    /// </summary>
    /// <param name="startVertex">стартовая вершина</param>
    /// <param name="graph">граф (дикшон узел - списко вершин)</param>
    /// <param name="colors">список окрашенности вершин</param>
    /// <returns></returns>
    private static bool CheckDFSToCycle(int startVertex, Dictionary<int, List<int>> graph, ref List<Colors> colors)
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(startVertex);

        while (stack.Count > 0)
        {
            var v = stack.Pop();

            //DebugPrintColor(colors);
            
            if (colors[v] == Colors.White)
            {
                colors[v] = Colors.Gray;

                stack.Push(v);

                //DebugPrintColor(colors);
                
                foreach (var w in graph[v])
                {
                    
                    if (colors[w] == Colors.White)
                        stack.Push(w);
                    else
                    {
                        if (colors[w] == Colors.Gray)
                            return true; // нашли цикл
                    }
                }
            }
            else
            {
                if (colors[v] == Colors.Gray)
                {
                    colors[v] = Colors.Black;
                }
            }
        }
        return false;
    }

    private static void DebugPrintColor(List<Colors> colors)
    {
        foreach (var color in colors)
        {
            writer.Write($"{(int)color} ");
        }
        writer.WriteLine();
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        List<string> mapList = new();
        for (int i = 0; i < n-1; i++)
        {
            string map = reader.ReadLine();
            mapList.Add(map);
        }

        AnalyseMap(n, mapList);

        reader.Close();
        writer.Close();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}

/*
3
RB
R

NO


4
BBB
RB
B

YES

5
RRRB
BRR
BR
R

NO
 */