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
        reader = new StreamReader(Console.OpenStandardInput(),  CodePagesEncodingProvider.Instance.GetEncoding(1252));
        writer = new StreamWriter(Console.OpenStandardOutput(), CodePagesEncodingProvider.Instance.GetEncoding(1252));
        
        //Console.WriteLine("The encoding used was {0}.", ((StreamReader)reader).CurrentEncoding);
        //Console.WriteLine("The encoding used was {0}.", ((StreamWriter)writer).Encoding);

        var n = ReadInt();

        Dictionary<string, int> hashMap = new Dictionary<string, int>();        

        for (int i = 0; i < n; i++)
        {
            var str = reader.ReadLine();            

            if (!hashMap.ContainsKey(str))
                hashMap[str]  = 1;

            hashMap[str]++;
        }

        foreach (var str in hashMap.Keys)
            writer.WriteLine(str);                   

        reader.Close();
        writer.Close();
    }

    
    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}