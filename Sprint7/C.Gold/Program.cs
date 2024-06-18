using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class C
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var m = ReadInt();

        var n = ReadInt();

        List<List<int>> dataList = new();

        for (int i = 0; i < n; i++)
        {
            var data = ReadList();

            dataList.Add(data);
        }

        MaxGoldPrice(m, dataList);


        reader.Close();
        writer.Close();
    }

    private static void MaxGoldPrice(int maxWeight, List<List<int>> dataList)
    {
        //отсортируем по уменьшению цены
        dataList.Sort(CompareByPrice);

        /*
        writer.WriteLine("------------");
        foreach (var data in dataList)
            writer.WriteLine($"{data[0]} {data[1]}");

        writer.WriteLine("------------");
        */

        var weight = 0;
        long price = 0;

        for(int i = 0; i < dataList.Count; i++) 
        {
            if (weight == maxWeight) 
                break;

            var delta = maxWeight - weight;

            // если куча поместится целиком
            if (dataList[i][1] < delta)
            {                                    
                weight += dataList[i][1];

                price += (long)dataList[i][1] * dataList[i][0];
            }
            else // положим сколько есть
            {
                weight += delta;
                price += (long)delta * dataList[i][0];
            }
        }

        writer.WriteLine(price);
    }

    private static int CompareByPrice(List<int> x, List<int> y)
    {
        if (x == null)
        {
            if (y == null)
            {
                return 0;
            }
            else
                return -1;
        }
        else
        {
            if (y == null)
                return 1;
            else
            {
                if (x[0] == y[0])
                    return (x[1].CompareTo(y[1]));
                else
                    return x[0].CompareTo(y[0]) * (-1);

            }
        }
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