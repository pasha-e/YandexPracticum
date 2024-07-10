using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class D
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());


        var n = ReadInt();

        List<string> arrStr = new List<string>();

        for(int i = 0; i < n; i++) 
        {
            var str = reader.ReadLine();

            arrStr.Add(str);
        }

        writer.WriteLine(CalcMaxPrefix(arrStr));          

        reader.Close();
        writer.Close();
    }

    private static int CalcMaxPrefix(List<string> arrStr)
    {
        if(arrStr.Count == 0) 
            return -1;

        string prefix = arrStr[0];

        for(int i = 1; i < arrStr.Count;  i++) 
        {
            var minLenght = Math.Min(prefix.Length, arrStr[i].Length);
            int j;
            for (j = 0; j < minLenght; j++)
            {
                if (prefix[j] != arrStr[i][j])
                    break;
            }

            prefix = arrStr[i][Range.EndAt(j)];

        }

        return prefix.Length;
    }


    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }

}

/*

3
abacaba
abudabi
abcdefg

2


2
tutu
kukuku

0


3
qwe
qwerty
qwerpy

3


 */