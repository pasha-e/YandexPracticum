using System;
using System.IO;

public class K
{
    private static TextReader reader;
    private static TextWriter writer;

    private static int CalcFibonachi(int n)
    {
        if (n < 2 )
            return 1;

        var result = CalcFibonachi(n-1) + CalcFibonachi(n - 2);

        return result;
    }



    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var n = ReadInt();
        
        writer.WriteLine(CalcFibonachi(n));
        
        reader.Close();
        writer.Close();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}