using System;
using System.IO;

public class G
{
    private static TextReader reader;
    private static TextWriter writer;

    private static string GetBinaryNumber(int number)
    {   
        string result = string.Empty;
        
        while (number >= 0)
        {
            var modulo = number % 2;

            result += modulo.ToString();            

            number /= 2;

            if (number == 0)
                break;
        }

        return ReverseString(result);
    }

    public static string ReverseString(string s)
    {
        char[] chArr = s.ToCharArray();
        Array.Reverse(chArr);
        return new string(chArr);
    }

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var number = ReadInt();
        writer.WriteLine(GetBinaryNumber(number));

        reader.Close();
        writer.Close();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}