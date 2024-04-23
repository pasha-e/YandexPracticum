using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Unicode;

public class A
{
    private static TextReader reader;
    private static TextWriter writer;

    

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        //Console.OutputEncoding = Encoding.UTF8;
        //Console.InputEncoding = Encoding.ASCII;        
        
        var n = ReadInt();

        Dictionary<string, int> hashMap = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            var str = reader.ReadLine();
                        
            if(!hashMap.ContainsKey(str))
                hashMap[str]  = 1;

            hashMap[str]++;
        }

        foreach (var str in hashMap.Keys)
            writer.WriteLine(str);
            

        Console.WriteLine("привет");

        reader.Close();
        writer.Close();
    }

    
    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }

    private static string UTF8ToWin1251(string sourceStr)
    {
        Encoding utf8 = Encoding.UTF8;
        Encoding win1251 = CodePagesEncodingProvider.Instance.GetEncoding(1251);
        byte[] utf8Bytes = utf8.GetBytes(sourceStr);
        byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
        return win1251.GetString(win1251Bytes);
    }

    static private string Win1251ToUTF8(string source)
    {
        Encoding utf8 = Encoding.UTF8;
        Encoding win1251 = CodePagesEncodingProvider.Instance.GetEncoding(1251);
        byte[] utf8Bytes = win1251.GetBytes(source);
        byte[] win1251Bytes = Encoding.Convert(win1251, utf8, utf8Bytes);
        source = win1251.GetString(win1251Bytes);
        return source;
    }
}