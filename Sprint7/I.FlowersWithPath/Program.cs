using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class I
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

            for (int j = 0; j < line.Length; j++)
                field[nm[0] - i - 1, j] = Int32.Parse(line[j].ToString());

        }

        var dp = CalcMaxCount(nm[0], nm[1], field);

        writer.WriteLine(dp[nm[0] - 1, nm[1] - 1]);

        var path = GetPath(nm[0], nm[1], dp);

        writer.WriteLine(path);

        reader.Close();
        writer.Close();
    }

    private static int[,] CalcMaxCount(int n, int m, int[,] field)
    {
        int[,] dp = new int[n, m];

        dp[0, 0] = field[0, 0];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (i == 0 && j == 0) // первая клетка уже пройдёна (базовый случай)
                    continue;

                //если выходим за рамки - считаем что  там ничего нет
                var byLine = i - 1 < 0 ? 0 : i - 1;
                var byRow = j - 1 < 0 ? 0 : j - 1;

                dp[i, j] = Max(dp[/*i - 1*/byLine, j], dp[i, /*j - 1*/byRow]) + field[i, j];
            }
        }

        return dp;
    }

    private static string GetPath(int n, int m, int[,] dp)
    {
        string path = string.Empty;
        
        int i = n - 1;
        int j = m - 1;

        while (i >= 0 && j >= 0)
        {
            if (i == 0 && j == 0)
                break;

            if(i - 1 < 0) // если по строкам (вниз) больше нельзя двигаться - значит только колонкам
            {
                path += "R";
                j--;
                continue;
            }

            if (j - 1 < 0) // если по Колонкам(влево) больше нельзя двигаться - значит только по строкам
            {
                path += "U";
                i--;
                continue;
            }

            // значение в клетке снизу больше чем справа и путь был через нее - значит Up
            if (dp[i - 1, j] > dp[i, j - 1])
            {
                i--;

                path += "U";
            }
            else // через ячейку слева от нас - значит Right
            {
                j--;

                path += "R";
            }

        }

       
        return Reverse(path);
    }

    private static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static int Max(int a, int b)
    {
        if (a > b)
            return a;

        return b;
    }

    // если больше a - значит значение в клетке снизу больше и путь был через нее - значит Up, b - через ячейку слева от нас - значит Right
    static char BestPath(int a, int b) 
    {
        if (a > b)
            return 'U';

        return 'R';
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
URR



3 3
100
110
001

2
UURR
 */