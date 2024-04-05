using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class B
{
    private static TextReader reader;
    private static TextWriter writer;

    
    //возможно выглядит странновато, зато работает для произвольного количества
    private static bool CheckParity(List<int> list)
    {
        bool? result = null;

        foreach (var item in list)
        {
            var isParity = item % 2 == 0; 

            if (!result.HasValue)
            {
                result = isParity;
                continue;
            }

            if (isParity != result) 
                return false;
        }

        return true;
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var list = ReadList();
        if (CheckParity(/*list[0], list[1], list[2])*/ list))
        {
            writer.WriteLine("WIN");
        }
        else
        {
            writer.WriteLine("FAIL");
        }

        reader.Close();
        writer.Close();
    }

    

    private static List<int> ReadList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
    }
}