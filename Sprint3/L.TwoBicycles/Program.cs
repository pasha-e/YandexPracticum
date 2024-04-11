using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class L
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();

        var list = ReadList();

        var price = ReadInt();

        var days = CalculateDayToPrice(n, list, price);


        foreach (var day in days)
        {
            writer.Write($"{day} ");
        }

        reader.Close();
        writer.Close();
    }

    private static List<int> CalculateDayToPrice(int n, List<int> list, int price)
    {
        var result = new List<int>();

        result.Add(BinSearch(list.ToArray(), price, left: 0, right: list.Count));

        result.Add(BinSearch(list.ToArray(), price*2, left: 0, right: list.Count));

        return result;
    }

    public static int BinSearch(int[] arr, int x, int left, int right)
    {
        if (right <= left) // промежуток пуст
        {
            return -1;
        }

        // промежуток не пуст
        int mid = (left + right) / 2;

        if (mid == 0 ||
            (arr[mid] >= x && 
            arr[mid-1] < x)) // центральный элемент — искомый
        {
            return mid + 1;
        }
        else if (x <= arr[mid]) 
        {
            return BinSearch(arr, x, left, mid);
        }
        else 
        {
            return BinSearch(arr, x, mid + 1, right);
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