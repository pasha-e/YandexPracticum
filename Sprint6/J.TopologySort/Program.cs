using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class J
{
    private static TextReader reader;
    private static TextWriter writer;

    //private static Dictionary<int, List<int>> map = new();
    private static List<List<int>> map = new();

    
    static Stack<int> _order = new (); // В этом стеке будет записан порядок обхода.
    //static List<byte> _color = new();
    private static byte[] _color;

    private static void CreateAdjacencyList(int n, int m)
    {
        map = new List<List<int>>();

        for (int i = 1; i <= n; i++)
            //map.Add(i, new List<int>());
            map.Add(new List<int>());
            

        //считывание
        for (int i = 0; i < m; i++)
        {
            var uv = ReadList();

            //map[uv[0]].Add(uv[1]);
            map[uv[0] - 1].Add(uv[1]);
        }

    }

    private static void TopSort2(int startVertex)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(startVertex);

        while (stack.Count > 0) 
        {
            int v = stack.Pop();

            if (_color[v - 1] == 0) //"white"
            {
                _color[v - 1] = 1; //"gray"
                stack.Push(v);

                var outgoingEdges = map[v - 1];//GetOutgoingEdges(v);
                //outgoingEdges.Sort();

                //if (outgoingEdges == null)
                //    break;

                foreach (int w in outgoingEdges)
                {
                    if (_color[w - 1] == 0) //"white"
                    {
                        stack.Push(w);
                    }
                }
            }
            else if (_color[v - 1] == 1) //"gray"
            {
                _color[v - 1] = 2; //"black"

                _order.Push(v);
            }
        }
    }

    private static void TopSort(int v)
    {
        _color[v-1] = 1; //"gray"
        foreach (int w in map[v - 1] )//GetOutgoingEdges(v))
        {
            if (_color[w-1] == 0) //"white"
            {
                TopSort(w);
            }
        }
        _color[v-1] = 2; //"black" 
        _order.Push(v); // Кладём обработанную вершину в стек.
        
    }

    private static void MainTopSort(int n)
    {
        _color = new byte[n];

        for (int i = 0; i < n; i++)
        {
            //_color.Add(0); //"white"
            _color[i] = 0;
        }

        for (int i = 0; i < n; i++)
        {
            if (_color[i] == 0) // "white"
            {
                TopSort2(i + 1);
            }
        }

        //вывод
        //var resStr = string.Empty;
        while (_order.Count > 0)
        {
            var val = _order.Pop();
            //resStr += $"{val} ";
            writer.Write($"{val} ");
        }
        

        //writer.WriteLine(resStr);
    }

    private static List<int> GetOutgoingEdges(int i)
    {
        //if (map.ContainsKey(i))
            return map[i-1];
        //return null;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var nm = ReadList();

        CreateAdjacencyList(nm[0], nm[1]); // считывать будем прям там раз такие приколы по мемори лимиту

        MainTopSort(nm[0]);

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