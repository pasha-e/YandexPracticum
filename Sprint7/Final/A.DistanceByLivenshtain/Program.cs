
/*
    https://contest.yandex.ru/contest/25597/run-report/115495270/
 */
/*
     -- ПРИНЦИП РАБОТЫ --

    https://ru.wikipedia.org/wiki/%D0%A0%D0%B0%D1%81%D1%81%D1%82%D0%BE%D1%8F%D0%BD%D0%B8%D0%B5_%D0%9B%D0%B5%D0%B2%D0%B5%D0%BD%D1%88%D1%82%D0%B5%D0%B9%D0%BD%D0%B0
    https://habr.com/ru/articles/676858/
     
     -- ВРЕМЕННАЯ СЛОЖНОСТЬ --
   
    
        
     -- ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ --
    
   
    
   */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class DistByLivenstain
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        string str1 = reader.ReadLine();
        string str2 = reader.ReadLine();

        var dist = CalcDistByLivestain(str1, str2);

        writer.WriteLine(dist);

        reader.Close();
        writer.Close();
    }

    private static int CalcDistByLivestain(string str1, string str2)
    {
        var n = str1.Length;
        var m = str2.Length;

        //для экономии будет  памяти выгоднее работать по короткой строке 
        if (n > m)
        {
            (str1, str2) = (str2, str1);
            (n, m) = (m, n);
        }

        //так как нам не надо знать конкретные замены на шагах, а только их количество,  
        //то нет необходимости хратить всю матрицу, достаточно только 2 строчки

        int[] currentRow = new int[n + 1];

        //базовый случай
        for(int i=0; i<currentRow.Length; i++)
            currentRow[i] = i;

        int[] prevRow = new int[n + 1];

        for (int i = 1; i <= m; i++)
        {
            for (int k = 0; k < prevRow.Length; k++)
                prevRow[k] = 0;

            prevRow[0] = i; // базовый случай

            (prevRow, currentRow) = (currentRow, prevRow);


            for (int j = 1; j <= n; j++)
            {
                var add = prevRow[j] + 1;
                var delete = currentRow[j-1] + 1;
                var change = prevRow[j-1];

                if (str1[j - 1] != str2[i - 1])
                    change += 1;

                currentRow[j] = Min(add,delete,change);
            }

        }

        return currentRow[n];
    }

    private static int Min(int a, int b, int c)
    {
        int[] arr = new[] { a, b, c };

        return arr.Min();
    }
}

/*
abacaba
abaabc

2

innokentiy
innnokkentia

3

r
x

1

dxqrpmratn
jdpmykgmaitn

8

yfalbhmqrz
twaqbre

7

pwhsvrojcj
uepwplklojcj

6

gthryaownz
ouuxcwysek

10

 */
