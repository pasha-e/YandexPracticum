using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class B
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        List<List<double>> dataList = new();

        for (int i = 0; i < n; i++)
        {
            var data = ReadList();

            dataList.Add(data);
        }        

        AnalyseSchedule(dataList);
        

        reader.Close();
        writer.Close();
    }



    private static void AnalyseSchedule(List<List<double>> dataList)
    {
        (double, double) record = (-1, -1);

        List<string> res = new List<string>();
        
        dataList.Sort(CompareByStart);

        /*writer.WriteLine("------------");
        foreach (var data in dataList)
            writer.WriteLine($"{data[0]} {data[1]}");

        writer.WriteLine("------------");*/

        foreach (var data in dataList)
        {
            var nextRec = GetBestEndTime(dataList, record);

            record = nextRec;

            if (record == (-1, -1))
                break;            
            res.Add($"{nextRec.Item1} {nextRec.Item2}");
        }

        writer.WriteLine(res.Count);

        foreach (var data in res)
            writer.WriteLine(data);
    }

    private static int CompareByStart(List<double> x, List<double> y)
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
                    return x[0].CompareTo(y[0]);

            }
        }
    }

    private static (double, double) GetBestEndTime(List<List<double>> dataList, (double, double) initTime)
    {
        double bestEndTime = -1;
       
        double startTime = -1;

        foreach (var data in dataList)
        {
            if (data[0] < initTime.Item2) // если время начала меньше чем окончание текущего - то это нам не подходит 
                continue;

            if (bestEndTime < 0 && 
                data[1] > initTime.Item1)
            {                
                bestEndTime = data[1];
                startTime = data[0];
                continue;
            }
            
            if (data[1] < bestEndTime)
            {
                //if (data[0] < startTime)
                {
                    bestEndTime = data[1];
                    startTime = data[0];
                    //break;
                }
            }
        }

        return (startTime, bestEndTime);
    }


    private static List<double> ReadList()
    {
        return reader.ReadLine()
            .Replace('.',',')
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToList();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}

/*


 */