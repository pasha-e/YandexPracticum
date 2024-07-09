using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

public class K
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var str1 = reader.ReadLine();
        var str2 = reader.ReadLine();

        var res = CompareStr(str1, str2);

        writer.WriteLine(res);

        reader.Close();
        writer.Close();
    }

    private static int CompareStr(string str1, string str2)
    {
        //создать алфавит для сравнения
        List<char> evenChars = new List<char>();

        for (int i = 'a'; i <= 'z'; i++)
        {
            if(i % 2 == 0)
                evenChars.Add((char)i);
        }

        StringBuilder newStr1 = new StringBuilder(string.Empty);
        StringBuilder newStr2 = new StringBuilder(string.Empty);
        //создать новые строки
        foreach (char ch in str1)
        {
            if (evenChars.Contains(ch))
                newStr1.Append(ch);
        }
        foreach (char ch in str2)
        {
            if (evenChars.Contains(ch))
                newStr2.Append(ch);
        }

        return newStr1.ToString().CompareTo(newStr2.ToString());
    }
}

/*

gggggbbb
bbef

-1


z
aaaaaaa

1

ccccz
aaaaaz

0

 */