using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class A
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var str = reader.ReadLine();

        string res = ReverseByWords(str);

        writer.WriteLine(res);

        reader.Close();
        writer.Close();
    }

    private static string ReverseByWords(string? str)
    {
        List<string>  arrWords = str.Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries).ToList();

        string res = string.Empty;

        for(int i = arrWords.Count -1;  i >= 0; i--) 
        {
            res += arrWords[i] + " " ;
        }        

        return res;
    }
}
