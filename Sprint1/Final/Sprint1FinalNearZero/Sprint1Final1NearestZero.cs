/*
 https://contest.yandex.ru/contest/22450/run-report/110979297/
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Sprint1Final1NearestZero
{
    private static TextReader reader;
    private static TextWriter writer;

    /// <summary>
    /// получить список расстояний до ближайшего пустого участка
    /// (по уму длинна улицы нам тут в целом не нужна, можно получать её как размер списка
    /// но раз в задании она есть и отдельно считывается, будем её использовать
    /// будем считать фукцию более универсальной, как будто она может анализировать скажем не весь список)
    /// </summary>
    /// <param name="numberList">список участков на улице</param>
    /// <param name="lenght">число участов на улице</param>
    /// <returns></returns>
    private static List<int> GetNearestZeroPosition(List<int> numberList, int lenght)
    {
        List<int> zeroPosition = new List<int>();

        List<int> result = new List<int>();

        //получим список позиций пустых участков
        for(int i=0; i < lenght; i++)
        {
            if (numberList[i] == 0) 
                zeroPosition.Add(i);
        }

        for (int i = 0; i < lenght; i++)
        {
            if (numberList[i] == 0)
            {
                result.Add(0);
                continue;
            }

            result.Add(GetMinNearestValue(zeroPosition, i));
        }

        return result;
    }

    /// <summary>
    /// получить миинмальное расстояние от текущего участка до ближайшего пустого
    /// (от текущего индекса до ближайшего нулевого индекса)
    /// </summary>
    /// <param name="zeroPositonList"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    private static int GetMinNearestValue(List<int> zeroPositonList, int position)
    {
        int result = Math.Abs(position - zeroPositonList[0]);

        for (int i = 1; i < zeroPositonList.Count; i++)
        {
            var distance = Math.Abs(position - zeroPositonList[i]);
            
            if (distance < result)
                result = distance;
        }
       
        return result;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var streetLength = ReadInt();
        var numberList = ReadList();        

        var sum = GetNearestZeroPosition(numberList, streetLength);

        writer.WriteLine(string.Join(" ", sum));

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