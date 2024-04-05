using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class L
{
    private static TextReader reader;
    private static TextWriter writer;

    // https://education.yandex.ru/handbook/algorithms/article/zadachi-o-chislah-fibonachchi
    /*
    F[0..n] — массив для промежуточных значений
    F[0] = 0
    F[1] = 1
    for i from 2 to n:
    F[i] = (F[i − 1] + F[i − 2]) mod 10
    return F[n]
    */

    private static int GetLastDigitFibonachi(int n, int k)
    {
        if (n < 2)
            return 1;

        int fibCur = 1;
        int fibPrev = 1;

        for (var i = 2; i <= n; i++)
        {
            var result = (fibCur + fibPrev) % (int)Math.Pow(10, k);
            fibPrev = fibCur;
            fibCur = result;
        }
        
        return fibCur;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var list = ReadList();

        writer.WriteLine(GetLastDigitFibonachi(list[0], list[1]));
        
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