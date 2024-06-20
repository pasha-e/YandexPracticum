using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class H
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());


        var nm = ReadList();

        int[,] field = new int[nm[0], nm[1]];

        for (int i = 0; i < nm[0]; i++)
        {
            var line = reader.ReadLine();

            //запишем матрицу чтобы строки были в обратном порядке

            for(int j =0; j < line.Length;  j++)
                field[nm[0]-i-1, j] = Int32.Parse(line[j].ToString());

        }
        
        int maxCount = CalcMaxCount(nm[0], nm[1], field);

        writer.WriteLine(maxCount);

        reader.Close();
        writer.Close();
    }

    private static int CalcMaxCount(int n, int m, int[,] field)
    {
        int[,] dp = new int[n, m];

        dp[0,0] = field[0,0];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if(i ==0 && j ==0) // первая клетка уже пройдёна (базовый случай)
                    continue;

                //если выходим за рамки - считаем что  там ничего нет
                var byLine = i - 1 < 0 ? 0 : i - 1;
                var byRow = j - 1 < 0 ? 0 : j - 1; 

                dp[i, j] = Max(dp[/*i - 1*/byLine, j], dp[i, /*j - 1*/byRow]) + field[i, j];
            }
        }

        return dp[n-1, m-1];
    }

    static int Max(int a, int b)
    {
        if(a > b )
            return a;

        return b;
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
2 3
101
110

3



3 3
100
110
001

2
 */