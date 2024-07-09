using System;
using System.Collections.Generic;
using System.Globalization;
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

        var str1 = reader.ReadLine();
        var str2 = reader.ReadLine();

        string res = CompareStr(str1, str2);

        writer.WriteLine(res);

        reader.Close();
        writer.Close();
    }

    private static string CompareStr(string str1, string str2)
    {
        var mistakeCount = 0;

        var maxMistakeCount = 1;

        var pos1= 0;
        var pos2= 0;

        while (pos1 < str1.Length && pos2 < str2.Length)
        {
            if (str1[pos1] == str2[pos2])
            {
                pos1++;
                pos2++;

                continue;
            }

            mistakeCount++;

            if (mistakeCount > maxMistakeCount)
                break;

            if (str1[Range.StartAt(pos1)].Length == str2[Range.StartAt(pos2)].Length)
            {
                pos1++;
                pos2++;
            }
            else
            {
                if (str1[Range.StartAt(pos1)].Length < str2[Range.StartAt(pos2)].Length)
                    pos2++;
                else
                {
                    pos1++;
                }
            }


        }

        return mistakeCount > 1 ? "FAIL" : "OK";
    }
}

/*
 
abcdefg
abdefg

OK

helo
hello

OK

dog
fog

OK

mama
papa

FAIL

 */