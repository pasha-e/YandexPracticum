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

        
        var str = reader.ReadLine();

        var res = PrefixFunction(str);

        foreach(var val in res)
            writer.Write($"{val} ");

        reader.Close();
        writer.Close();
    }

    static List<int> PrefixFunction(string s)
    {
        // Функция возвращает массив длины |s|
        int n = s.Length;
        List<int> pi = new List<int>(new int[n]);
        pi[0] = 0;
        for (int i = 1; i < n; ++i)
        {
            int k = pi[i - 1];
            while (k > 0 && s[k] != s[i])
            {
                k = pi[k - 1];
            }
            if (s[k] == s[i])
            {
                ++k;
            }
            pi[i] = k;
        }

        return pi;
    }


}

/*

abracadabra
0 0 0 1 0 1 0 1 2 3 4 

xxzzxxz
0 1 0 0 1 2 3

aaaaa
0 1 2 3 4 
 */